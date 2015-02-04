using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ys = YouTube.YoutubeService;

namespace YouTubeDownloader.UI
{
    public partial class frmAddVideo : Form
    {
        public frmAddVideo()
        {
            InitializeComponent();
        }

        public string Link
        {
            get { return txtLink.Text; }
            set { txtLink.Text = value; }
        }

        private void frmAddVideo_Load(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (ys.isValidYouTubeUrl(clipboardText))
            {
                txtLink.Text = clipboardText;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Link = string.Empty;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ys.isValidYouTubeUrl(Link))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Invalid YouTube link", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}