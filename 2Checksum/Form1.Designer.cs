namespace _2Checksum
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Button_Browse = new System.Windows.Forms.Button();
            this.Button_Copy = new System.Windows.Forms.Button();
            this.RadioButton_4digitChecksum = new System.Windows.Forms.RadioButton();
            this.RadioButton_8digitChecksum = new System.Windows.Forms.RadioButton();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RichTextBox_FileInfo = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // Button_Browse
            // 
            this.Button_Browse.Image = ((System.Drawing.Image)(resources.GetObject("Button_Browse.Image")));
            this.Button_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Browse.Location = new System.Drawing.Point(298, 45);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(109, 39);
            this.Button_Browse.TabIndex = 0;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Browse.UseVisualStyleBackColor = true;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.Image = ((System.Drawing.Image)(resources.GetObject("Button_Copy.Image")));
            this.Button_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Copy.Location = new System.Drawing.Point(298, 90);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(109, 39);
            this.Button_Copy.TabIndex = 1;
            this.Button_Copy.Text = "Copy";
            this.Button_Copy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Copy.UseVisualStyleBackColor = true;
            // 
            // RadioButton_4digitChecksum
            // 
            this.RadioButton_4digitChecksum.AutoSize = true;
            this.RadioButton_4digitChecksum.Checked = true;
            this.RadioButton_4digitChecksum.Location = new System.Drawing.Point(12, 12);
            this.RadioButton_4digitChecksum.Name = "RadioButton_4digitChecksum";
            this.RadioButton_4digitChecksum.Size = new System.Drawing.Size(137, 18);
            this.RadioButton_4digitChecksum.TabIndex = 2;
            this.RadioButton_4digitChecksum.TabStop = true;
            this.RadioButton_4digitChecksum.Text = "4-Digit Checksum";
            this.RadioButton_4digitChecksum.UseVisualStyleBackColor = true;
            this.RadioButton_4digitChecksum.CheckedChanged += new System.EventHandler(this.RadioButton_4digitChecksum_CheckedChanged);
            // 
            // RadioButton_8digitChecksum
            // 
            this.RadioButton_8digitChecksum.AutoSize = true;
            this.RadioButton_8digitChecksum.Location = new System.Drawing.Point(155, 12);
            this.RadioButton_8digitChecksum.Name = "RadioButton_8digitChecksum";
            this.RadioButton_8digitChecksum.Size = new System.Drawing.Size(137, 18);
            this.RadioButton_8digitChecksum.TabIndex = 3;
            this.RadioButton_8digitChecksum.Text = "8-Digit Checksum";
            this.RadioButton_8digitChecksum.UseVisualStyleBackColor = true;
            this.RadioButton_8digitChecksum.CheckedChanged += new System.EventHandler(this.RadioButton_8digitChecksum_CheckedChanged);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // RichTextBox_FileInfo
            // 
            this.RichTextBox_FileInfo.BackColor = System.Drawing.SystemColors.Window;
            this.RichTextBox_FileInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_FileInfo.Location = new System.Drawing.Point(12, 36);
            this.RichTextBox_FileInfo.Name = "RichTextBox_FileInfo";
            this.RichTextBox_FileInfo.ReadOnly = true;
            this.RichTextBox_FileInfo.Size = new System.Drawing.Size(280, 93);
            this.RichTextBox_FileInfo.TabIndex = 6;
            this.RichTextBox_FileInfo.Text = "";
            this.RichTextBox_FileInfo.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(416, 138);
            this.Controls.Add(this.RichTextBox_FileInfo);
            this.Controls.Add(this.RadioButton_8digitChecksum);
            this.Controls.Add(this.RadioButton_4digitChecksum);
            this.Controls.Add(this.Button_Copy);
            this.Controls.Add(this.Button_Browse);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2Checksum";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.Button Button_Copy;
        private System.Windows.Forms.RadioButton RadioButton_4digitChecksum;
        private System.Windows.Forms.RadioButton RadioButton_8digitChecksum;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.RichTextBox RichTextBox_FileInfo;
    }
}

