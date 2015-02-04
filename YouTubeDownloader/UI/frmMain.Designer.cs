namespace YouTubeDownloader.UI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.progressbar = new YouTubeDownloader.UI.Controls.IndeterminateProgressbar();
            this.btnDownloadSelected = new System.Windows.Forms.Label();
            this.btnRemoveSelected = new System.Windows.Forms.Label();
            this.btnAddVideo = new System.Windows.Forms.Label();
            this._LstYoutubes = new YouTubeDownloader.UI.Controls.YoutubeListView();
            this.SuspendLayout();
            // 
            // progressbar
            // 
            this.progressbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.progressbar.Enabled = false;
            this.progressbar.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.progressbar.Location = new System.Drawing.Point(0, 48);
            this.progressbar.Name = "progressbar";
            this.progressbar.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this.progressbar.Size = new System.Drawing.Size(659, 4);
            this.progressbar.TabIndex = 7;
            this.progressbar.Text = "indeterminateProgressbar1";
            // 
            // btnDownloadSelected
            // 
            this.btnDownloadSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadSelected.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDownloadSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnDownloadSelected.Image")));
            this.btnDownloadSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadSelected.Location = new System.Drawing.Point(545, 10);
            this.btnDownloadSelected.Name = "btnDownloadSelected";
            this.btnDownloadSelected.Size = new System.Drawing.Size(102, 27);
            this.btnDownloadSelected.TabIndex = 6;
            this.btnDownloadSelected.Text = "Download";
            this.btnDownloadSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDownloadSelected.Click += new System.EventHandler(this.btnDownloadSelected_Click);
            // 
            // btnRemoveSelected
            // 
            this.btnRemoveSelected.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveSelected.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnRemoveSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveSelected.Image")));
            this.btnRemoveSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemoveSelected.Location = new System.Drawing.Point(140, 10);
            this.btnRemoveSelected.Name = "btnRemoveSelected";
            this.btnRemoveSelected.Size = new System.Drawing.Size(90, 27);
            this.btnRemoveSelected.TabIndex = 5;
            this.btnRemoveSelected.Text = "Remove";
            this.btnRemoveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemoveSelected.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVideo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVideo.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnAddVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVideo.Image")));
            this.btnAddVideo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddVideo.Location = new System.Drawing.Point(12, 10);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(106, 27);
            this.btnAddVideo.TabIndex = 4;
            this.btnAddVideo.Text = "Add video";
            this.btnAddVideo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            // 
            // _LstYoutubes
            // 
            this._LstYoutubes.AutoScroll = true;
            this._LstYoutubes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this._LstYoutubes.BackgroundImage = global::YouTubeDownloader.Properties.Resources.TuzkiJapan2;
            this._LstYoutubes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._LstYoutubes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this._LstYoutubes.Location = new System.Drawing.Point(0, 52);
            this._LstYoutubes.Name = "_LstYoutubes";
            this._LstYoutubes.Size = new System.Drawing.Size(659, 369);
            this._LstYoutubes.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(659, 421);
            this.Controls.Add(this.progressbar);
            this.Controls.Add(this.btnDownloadSelected);
            this.Controls.Add(this.btnRemoveSelected);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this._LstYoutubes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 320);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SUSU YouTube to MP3";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.YoutubeListView _LstYoutubes;
        private System.Windows.Forms.Label btnAddVideo;
        private System.Windows.Forms.Label btnRemoveSelected;
        private System.Windows.Forms.Label btnDownloadSelected;
        private Controls.IndeterminateProgressbar progressbar;
    }
}