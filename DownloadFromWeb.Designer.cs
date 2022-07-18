namespace GetTruyen
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.txbUrl = new System.Windows.Forms.TextBox();
            this.grpUrl = new System.Windows.Forms.GroupBox();
            this.btnGetList = new System.Windows.Forms.Button();
            this.btnDownAll = new System.Windows.Forms.Button();
            this.btnDownByChapter = new System.Windows.Forms.Button();
            this.ckdChapterList = new System.Windows.Forms.CheckedListBox();
            this.fbdDirPath = new System.Windows.Forms.FolderBrowserDialog();
            this.txbStatus = new System.Windows.Forms.TextBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.ckdSelectAll = new System.Windows.Forms.CheckBox();
            this.grpUrl.SuspendLayout();
            this.pnl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbUrl
            // 
            this.txbUrl.Location = new System.Drawing.Point(6, 19);
            this.txbUrl.Name = "txbUrl";
            this.txbUrl.Size = new System.Drawing.Size(468, 20);
            this.txbUrl.TabIndex = 0;
            // 
            // grpUrl
            // 
            this.grpUrl.Controls.Add(this.txbUrl);
            this.grpUrl.Location = new System.Drawing.Point(13, 12);
            this.grpUrl.Name = "grpUrl";
            this.grpUrl.Size = new System.Drawing.Size(481, 50);
            this.grpUrl.TabIndex = 1;
            this.grpUrl.TabStop = false;
            this.grpUrl.Text = "Nhập Url";
            // 
            // btnGetList
            // 
            this.btnGetList.Location = new System.Drawing.Point(12, 68);
            this.btnGetList.Name = "btnGetList";
            this.btnGetList.Size = new System.Drawing.Size(100, 23);
            this.btnGetList.TabIndex = 1;
            this.btnGetList.Text = "Lấy danh sách truyện";
            this.btnGetList.UseVisualStyleBackColor = true;
            this.btnGetList.Click += new System.EventHandler(this.btnGetList_Click);
            // 
            // btnDownAll
            // 
            this.btnDownAll.Location = new System.Drawing.Point(3, 2);
            this.btnDownAll.Name = "btnDownAll";
            this.btnDownAll.Size = new System.Drawing.Size(175, 23);
            this.btnDownAll.TabIndex = 2;
            this.btnDownAll.Text = "Tải hết";
            this.btnDownAll.UseVisualStyleBackColor = true;
            this.btnDownAll.Click += new System.EventHandler(this.btnDownAll_Click);
            // 
            // btnDownByChapter
            // 
            this.btnDownByChapter.Location = new System.Drawing.Point(191, 3);
            this.btnDownByChapter.Name = "btnDownByChapter";
            this.btnDownByChapter.Size = new System.Drawing.Size(175, 23);
            this.btnDownByChapter.TabIndex = 3;
            this.btnDownByChapter.Text = "Tải Theo Chap";
            this.btnDownByChapter.UseVisualStyleBackColor = true;
            this.btnDownByChapter.Click += new System.EventHandler(this.btnDownByChapter_Click);
            // 
            // ckdChapterList
            // 
            this.ckdChapterList.CheckOnClick = true;
            this.ckdChapterList.FormattingEnabled = true;
            this.ckdChapterList.Location = new System.Drawing.Point(13, 132);
            this.ckdChapterList.Name = "ckdChapterList";
            this.ckdChapterList.Size = new System.Drawing.Size(474, 499);
            this.ckdChapterList.TabIndex = 5;
            // 
            // fbdDirPath
            // 
            this.fbdDirPath.Description = "Chọn đường dẫn đến nơi bạn muốn lưu truyện";
            // 
            // txbStatus
            // 
            this.txbStatus.BackColor = System.Drawing.SystemColors.Control;
            this.txbStatus.Enabled = false;
            this.txbStatus.Location = new System.Drawing.Point(119, 106);
            this.txbStatus.Name = "txbStatus";
            this.txbStatus.Size = new System.Drawing.Size(150, 20);
            this.txbStatus.TabIndex = 9;
            this.txbStatus.Text = "Đang chờ tải...";
            this.txbStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnl1
            // 
            this.pnl1.Controls.Add(this.btnDownAll);
            this.pnl1.Controls.Add(this.btnDownByChapter);
            this.pnl1.Enabled = false;
            this.pnl1.Location = new System.Drawing.Point(116, 64);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(371, 29);
            this.pnl1.TabIndex = 10;
            // 
            // ckdSelectAll
            // 
            this.ckdSelectAll.AutoSize = true;
            this.ckdSelectAll.Enabled = false;
            this.ckdSelectAll.Location = new System.Drawing.Point(17, 112);
            this.ckdSelectAll.Name = "ckdSelectAll";
            this.ckdSelectAll.Size = new System.Drawing.Size(69, 17);
            this.ckdSelectAll.TabIndex = 4;
            this.ckdSelectAll.Text = "Select all";
            this.ckdSelectAll.UseVisualStyleBackColor = true;
            this.ckdSelectAll.CheckedChanged += new System.EventHandler(this.ckdSelectAll_CheckedChanged);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 644);
            this.Controls.Add(this.ckdSelectAll);
            this.Controls.Add(this.pnl1);
            this.Controls.Add(this.txbStatus);
            this.Controls.Add(this.ckdChapterList);
            this.Controls.Add(this.btnGetList);
            this.Controls.Add(this.grpUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Get Truyện By NhutLe";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.grpUrl.ResumeLayout(false);
            this.grpUrl.PerformLayout();
            this.pnl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbUrl;
        private System.Windows.Forms.GroupBox grpUrl;
        private System.Windows.Forms.Button btnGetList;
        private System.Windows.Forms.Button btnDownAll;
        private System.Windows.Forms.Button btnDownByChapter;
        private System.Windows.Forms.CheckedListBox ckdChapterList;
        private System.Windows.Forms.FolderBrowserDialog fbdDirPath;
        private System.Windows.Forms.TextBox txbStatus;
        private System.Windows.Forms.Panel pnl1;
        private System.Windows.Forms.CheckBox ckdSelectAll;
    }
}

