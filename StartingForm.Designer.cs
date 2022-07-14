namespace GetTruyen
{
    partial class StartingForm
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
            this.btnWebTruyen = new System.Windows.Forms.Button();
            this.btnFaceBook = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWebTruyen
            // 
            this.btnWebTruyen.Location = new System.Drawing.Point(30, 48);
            this.btnWebTruyen.Name = "btnWebTruyen";
            this.btnWebTruyen.Size = new System.Drawing.Size(192, 61);
            this.btnWebTruyen.TabIndex = 0;
            this.btnWebTruyen.Text = "Download Truyện trên web";
            this.btnWebTruyen.UseVisualStyleBackColor = true;
            this.btnWebTruyen.Click += new System.EventHandler(this.btnWebTruyen_Click);
            // 
            // btnFaceBook
            // 
            this.btnFaceBook.Location = new System.Drawing.Point(260, 48);
            this.btnFaceBook.Name = "btnFaceBook";
            this.btnFaceBook.Size = new System.Drawing.Size(192, 61);
            this.btnFaceBook.TabIndex = 1;
            this.btnFaceBook.Text = "Download truyện/album trên facebook";
            this.btnFaceBook.UseVisualStyleBackColor = true;
            this.btnFaceBook.Click += new System.EventHandler(this.btnFaceBook_Click);
            // 
            // StartingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 158);
            this.Controls.Add(this.btnFaceBook);
            this.Controls.Add(this.btnWebTruyen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWebTruyen;
        private System.Windows.Forms.Button btnFaceBook;
    }
}