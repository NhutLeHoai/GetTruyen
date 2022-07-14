namespace GetTruyen
{
    partial class fFBDownloader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fFBDownloader));
            this.txbFBUrl = new System.Windows.Forms.TextBox();
            this.gpDownload = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gpAT = new System.Windows.Forms.GroupBox();
            this.btnToken1 = new System.Windows.Forms.Button();
            this.txbAccessToken = new System.Windows.Forms.TextBox();
            this.getSavePlace = new System.Windows.Forms.FolderBrowserDialog();
            this.ckbAlbumList = new System.Windows.Forms.CheckedListBox();
            this.lbGroupName = new System.Windows.Forms.Label();
            this.txbStatus = new System.Windows.Forms.TextBox();
            this.txbDownloadStatus = new System.Windows.Forms.TextBox();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.saveAccessToken = new System.Windows.Forms.Button();
            this.gpDownload.SuspendLayout();
            this.gpAT.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbFBUrl
            // 
            this.txbFBUrl.Location = new System.Drawing.Point(6, 19);
            this.txbFBUrl.Name = "txbFBUrl";
            this.txbFBUrl.Size = new System.Drawing.Size(299, 20);
            this.txbFBUrl.TabIndex = 2;
            // 
            // gpDownload
            // 
            this.gpDownload.Controls.Add(this.btnDownload);
            this.gpDownload.Controls.Add(this.txbFBUrl);
            this.gpDownload.Controls.Add(this.btnSubmit);
            this.gpDownload.Location = new System.Drawing.Point(12, 67);
            this.gpDownload.Name = "gpDownload";
            this.gpDownload.Size = new System.Drawing.Size(614, 49);
            this.gpDownload.TabIndex = 1;
            this.gpDownload.TabStop = false;
            this.gpDownload.Text = "Nhập Url nhóm Facebook";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(468, 16);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(137, 23);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(311, 16);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(137, 23);
            this.btnSubmit.TabIndex = 3;
            this.btnSubmit.Text = "Lấy dữ liệu";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // gpAT
            // 
            this.gpAT.Controls.Add(this.saveAccessToken);
            this.gpAT.Controls.Add(this.btnToken1);
            this.gpAT.Controls.Add(this.txbAccessToken);
            this.gpAT.Location = new System.Drawing.Point(12, 12);
            this.gpAT.Name = "gpAT";
            this.gpAT.Size = new System.Drawing.Size(614, 49);
            this.gpAT.TabIndex = 5;
            this.gpAT.TabStop = false;
            this.gpAT.Text = "Nhập Access Token";
            // 
            // btnToken1
            // 
            this.btnToken1.Location = new System.Drawing.Point(311, 16);
            this.btnToken1.Name = "btnToken1";
            this.btnToken1.Size = new System.Drawing.Size(137, 23);
            this.btnToken1.TabIndex = 1;
            this.btnToken1.Text = "Lấy Access Token";
            this.btnToken1.UseVisualStyleBackColor = true;
            this.btnToken1.Click += new System.EventHandler(this.btnToken1_Click);
            // 
            // txbAccessToken
            // 
            this.txbAccessToken.Location = new System.Drawing.Point(6, 19);
            this.txbAccessToken.Name = "txbAccessToken";
            this.txbAccessToken.Size = new System.Drawing.Size(299, 20);
            this.txbAccessToken.TabIndex = 0;
            // 
            // ckbAlbumList
            // 
            this.ckbAlbumList.CheckOnClick = true;
            this.ckbAlbumList.FormattingEnabled = true;
            this.ckbAlbumList.Location = new System.Drawing.Point(12, 204);
            this.ckbAlbumList.Name = "ckbAlbumList";
            this.ckbAlbumList.Size = new System.Drawing.Size(614, 409);
            this.ckbAlbumList.TabIndex = 5;
            // 
            // lbGroupName
            // 
            this.lbGroupName.AutoSize = true;
            this.lbGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGroupName.Location = new System.Drawing.Point(15, 161);
            this.lbGroupName.Name = "lbGroupName";
            this.lbGroupName.Padding = new System.Windows.Forms.Padding(3);
            this.lbGroupName.Size = new System.Drawing.Size(380, 28);
            this.lbGroupName.TabIndex = 6;
            this.lbGroupName.Text = "Vui lòng nhập thông tin để tìm kiếm/download";
            // 
            // txbStatus
            // 
            this.txbStatus.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbStatus.Enabled = false;
            this.txbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbStatus.Location = new System.Drawing.Point(15, 122);
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.ReadOnly = true;
            this.txbStatus.Size = new System.Drawing.Size(445, 23);
            this.txbStatus.TabIndex = 7;
            this.txbStatus.Text = "Đang chờ...";
            this.txbStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbStatus.WordWrap = false;
            // 
            // txbDownloadStatus
            // 
            this.txbDownloadStatus.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txbDownloadStatus.Enabled = false;
            this.txbDownloadStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDownloadStatus.Location = new System.Drawing.Point(480, 122);
            this.txbDownloadStatus.Name = "txbDownloadStatus";
            this.txbDownloadStatus.ReadOnly = true;
            this.txbDownloadStatus.Size = new System.Drawing.Size(146, 23);
            this.txbDownloadStatus.TabIndex = 8;
            this.txbDownloadStatus.Text = "Waiting for download...";
            this.txbDownloadStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbDownloadStatus.WordWrap = false;
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(480, 151);
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(146, 23);
            this.progressDownload.TabIndex = 9;
            // 
            // saveAccessToken
            // 
            this.saveAccessToken.Location = new System.Drawing.Point(468, 16);
            this.saveAccessToken.Name = "saveAccessToken";
            this.saveAccessToken.Size = new System.Drawing.Size(137, 23);
            this.saveAccessToken.TabIndex = 2;
            this.saveAccessToken.Text = "Lưu Access Token";
            this.saveAccessToken.UseVisualStyleBackColor = true;
            this.saveAccessToken.Click += new System.EventHandler(this.saveAccessToken_Click);
            // 
            // fFBDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 622);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.txbDownloadStatus);
            this.Controls.Add(this.txbStatus);
            this.Controls.Add(this.lbGroupName);
            this.Controls.Add(this.ckbAlbumList);
            this.Controls.Add(this.gpAT);
            this.Controls.Add(this.gpDownload);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fFBDownloader";
            this.Text = "Tải Album Facebook By NhutLe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fFBDownloader_FormClosed);
            this.Load += new System.EventHandler(this.fFBDownloader_Load);
            this.gpDownload.ResumeLayout(false);
            this.gpDownload.PerformLayout();
            this.gpAT.ResumeLayout(false);
            this.gpAT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbFBUrl;
        private System.Windows.Forms.GroupBox gpDownload;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox gpAT;
        private System.Windows.Forms.TextBox txbAccessToken;
        private System.Windows.Forms.Button btnToken1;
        private System.Windows.Forms.FolderBrowserDialog getSavePlace;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.CheckedListBox ckbAlbumList;
        private System.Windows.Forms.Label lbGroupName;
        private System.Windows.Forms.TextBox txbStatus;
        private System.Windows.Forms.TextBox txbDownloadStatus;
        private System.Windows.Forms.ProgressBar progressDownload;
        private System.Windows.Forms.Button saveAccessToken;
    }
}