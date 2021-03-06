﻿using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NReco.VideoConverter;
using YouTube;
using YouTubeDownloader.UI.Controls;

namespace YouTubeDownloader.UI
{
    public partial class frmMain : Form
    {
        private int videosProcessing;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // addURLfromClipboard();
        }

        private async void addURL(string url)
        {
            Action incrementVideoProcessing = () =>
            {
                Interlocked.Increment(ref videosProcessing);
                progressbar.Invoke(new MethodInvoker(() => progressbar.Enabled = true));
            };

            Action decrementVideoProcessing = () =>
            {
                Interlocked.Decrement(ref videosProcessing);
                if (videosProcessing == 0)
                    progressbar.Invoke(new MethodInvoker(() => progressbar.Enabled = false));
            };

            Action<AudioInformation> addToList = (audioInformation) =>
            {
                incrementVideoProcessing();

                if (_LstYoutubes.FindItemByVideo(audioInformation) == null)
                {
                    _LstYoutubes.AddItem(audioInformation).Checked = true;
                }

                decrementVideoProcessing();
            };

            if (YoutubeService.isSingleVideoUrl(url))
            {
                incrementVideoProcessing();

                var audioInformation = await YoutubeService.FetchAudioInformation(url);
                if (audioInformation != null)
                    addToList(audioInformation);

                decrementVideoProcessing();
            }
            else if (YoutubeService.isPlaylistUrl(url))
            {
                incrementVideoProcessing();
                await YoutubeService.FetchPlaylistInformation(url, addToList, decrementVideoProcessing);
            }
        }

        private void addURLfromClipboard()
        {
            var url = Clipboard.GetText();
            addURL(url);
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Control)
            {
                addURLfromClipboard();
            }
        }

        private void btnAddVideo_Click(object sender, EventArgs e)
        {
            // addURLfromClipboard();
            frmAddVideo addVideoForm = new frmAddVideo();

            if (addVideoForm.ShowDialog(this) == DialogResult.OK)
            {
                addURL(addVideoForm.Link);
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            foreach (AudioInformation audio in _LstYoutubes.SelectedVideos())
            {
                _LstYoutubes.RemoveItem(audio);
            }
        }

        private void btnDownloadSelected_Click(object sender, EventArgs ea)
        {
            foreach (YoutubeListView.AudioItem selectedItem in _LstYoutubes.SelectedItems())
            {
                if (selectedItem.DownloadStatus != YoutubeListView.AudioItem.DownloadStatuses.NotDownloaded) continue;

                var invalidChars = Path.GetInvalidFileNameChars();
                string fixedTitle = new string(selectedItem._Audio.Title.Where(x => !invalidChars.Contains(x)).ToArray());

                YoutubeDownloader youtubeDownloader = new YoutubeDownloader();
                youtubeDownloader.OnDownloadProgressChanged += (s, e) =>
                {
                    selectedItem.DownloadStatus = YoutubeListView.AudioItem.DownloadStatuses.Downloading;
                    selectedItem.DownloadProgress = e.ProgressPercentage * 0.5f;
                };
                youtubeDownloader.OnDownloadFailed += (s, ex) =>
                {
                    selectedItem.DownloadStatus = YoutubeListView.AudioItem.DownloadStatuses.Error;
                    MessageBox.Show(String.Format("An error has occured.\n{0}", ex.ToString()),
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                };
                youtubeDownloader.OnDownloadCompleted += (s, video) =>
                {
                    selectedItem.DownloadStatus = YoutubeListView.AudioItem.DownloadStatuses.Converting;

                    FFMpegConverter ffMpeg = new FFMpegConverter();
                    ffMpeg.ConvertProgress += (ss, progress) =>
                    {
                        selectedItem.DownloadProgress = 50 +
                            (float)((progress.Processed.TotalMinutes / progress.TotalDuration.TotalMinutes) * 50);
                    };

                    FileStream fileStream = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                        + "\\" + fixedTitle + ".mp3", FileMode.Create);

                    ffMpeg.LogReceived += async (ss, log) =>
                    {
                        if (!log.Data.StartsWith("video:0kB")) return;

                        Invoke(new MethodInvoker(() =>
                        {
                            selectedItem.DownloadStatus = YoutubeListView.AudioItem.DownloadStatuses.Completed;
                        }));

                        await Task.Delay(1000);
                        fileStream.Close();
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                            + "\\" + fixedTitle + ".mp4");
                    };

                    new Thread(() => ffMpeg.ConvertMedia(
                        Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + fixedTitle + ".mp4",
                        "mp4",
                        fileStream,
                        "mp3",
                        new ConvertSettings { AudioCodec = "libmp3lame", CustomOutputArgs = "-q:a 0" }
                        )).Start();
                };

                var highestQualityAvailable = selectedItem._Audio.GetHighestQualityTuple();
                youtubeDownloader.DownloadAudioAsync(selectedItem._Audio, highestQualityAvailable.Item1,
                    highestQualityAvailable.Item2, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                    + "\\" + fixedTitle + ".mp4");
            }
        }
    }
}