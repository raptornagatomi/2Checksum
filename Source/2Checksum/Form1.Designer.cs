﻿namespace _2Checksum
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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RichTextBox_FileInfo = new System.Windows.Forms.RichTextBox();
            this.CheckBox_Verbose = new System.Windows.Forms.CheckBox();
            this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.CheckBox_DigitLength = new System.Windows.Forms.CheckBox();
            this.Button_Export = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_Browse
            // 
            this.Button_Browse.BackColor = System.Drawing.Color.White;
            this.Button_Browse.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.Button_Browse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Browse.Image = ((System.Drawing.Image)(resources.GetObject("Button_Browse.Image")));
            this.Button_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Browse.Location = new System.Drawing.Point(378, 56);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(141, 38);
            this.Button_Browse.TabIndex = 0;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Browse.UseVisualStyleBackColor = false;
            this.Button_Browse.Click += new System.EventHandler(this.Button_Browse_Click);
            // 
            // Button_Copy
            // 
            this.Button_Copy.BackColor = System.Drawing.Color.White;
            this.Button_Copy.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.Button_Copy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Copy.Image = ((System.Drawing.Image)(resources.GetObject("Button_Copy.Image")));
            this.Button_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Copy.Location = new System.Drawing.Point(380, 12);
            this.Button_Copy.Name = "Button_Copy";
            this.Button_Copy.Size = new System.Drawing.Size(141, 38);
            this.Button_Copy.TabIndex = 1;
            this.Button_Copy.Text = "Copy";
            this.Button_Copy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Copy.UseVisualStyleBackColor = false;
            this.Button_Copy.Click += new System.EventHandler(this.Button_Copy_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // RichTextBox_FileInfo
            // 
            this.RichTextBox_FileInfo.BackColor = System.Drawing.Color.White;
            this.RichTextBox_FileInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RichTextBox_FileInfo.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextBox_FileInfo.ForeColor = System.Drawing.Color.Black;
            this.RichTextBox_FileInfo.Location = new System.Drawing.Point(12, 12);
            this.RichTextBox_FileInfo.Name = "RichTextBox_FileInfo";
            this.RichTextBox_FileInfo.ReadOnly = true;
            this.RichTextBox_FileInfo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.RichTextBox_FileInfo.Size = new System.Drawing.Size(360, 196);
            this.RichTextBox_FileInfo.TabIndex = 6;
            this.RichTextBox_FileInfo.Text = "";
            this.RichTextBox_FileInfo.WordWrap = false;
            // 
            // CheckBox_Verbose
            // 
            this.CheckBox_Verbose.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_Verbose.AutoSize = true;
            this.CheckBox_Verbose.Checked = true;
            this.CheckBox_Verbose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_Verbose.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.CheckBox_Verbose.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGray;
            this.CheckBox_Verbose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox_Verbose.Location = new System.Drawing.Point(378, 177);
            this.CheckBox_Verbose.Name = "CheckBox_Verbose";
            this.CheckBox_Verbose.Size = new System.Drawing.Size(74, 27);
            this.CheckBox_Verbose.TabIndex = 7;
            this.CheckBox_Verbose.Text = "Verbose";
            this.CheckBox_Verbose.UseVisualStyleBackColor = true;
            this.CheckBox_Verbose.Click += new System.EventHandler(this.CheckBox_Verbose_Click);
            // 
            // PictureBox_Logo
            // 
            this.PictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Logo.Image")));
            this.PictureBox_Logo.Location = new System.Drawing.Point(473, 160);
            this.PictureBox_Logo.Name = "PictureBox_Logo";
            this.PictureBox_Logo.Size = new System.Drawing.Size(48, 48);
            this.PictureBox_Logo.TabIndex = 8;
            this.PictureBox_Logo.TabStop = false;
            // 
            // CheckBox_DigitLength
            // 
            this.CheckBox_DigitLength.Appearance = System.Windows.Forms.Appearance.Button;
            this.CheckBox_DigitLength.AutoSize = true;
            this.CheckBox_DigitLength.Checked = true;
            this.CheckBox_DigitLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_DigitLength.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.CheckBox_DigitLength.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightGray;
            this.CheckBox_DigitLength.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CheckBox_DigitLength.Location = new System.Drawing.Point(378, 144);
            this.CheckBox_DigitLength.Name = "CheckBox_DigitLength";
            this.CheckBox_DigitLength.Size = new System.Drawing.Size(74, 27);
            this.CheckBox_DigitLength.TabIndex = 9;
            this.CheckBox_DigitLength.Text = "8-digit";
            this.CheckBox_DigitLength.UseVisualStyleBackColor = true;
            this.CheckBox_DigitLength.CheckedChanged += new System.EventHandler(this.CheckBox_DigitLength_CheckedChanged);
            // 
            // Button_Export
            // 
            this.Button_Export.Image = ((System.Drawing.Image)(resources.GetObject("Button_Export.Image")));
            this.Button_Export.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Export.Location = new System.Drawing.Point(378, 100);
            this.Button_Export.Name = "Button_Export";
            this.Button_Export.Size = new System.Drawing.Size(141, 38);
            this.Button_Export.TabIndex = 10;
            this.Button_Export.Text = "Export";
            this.Button_Export.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Export.UseVisualStyleBackColor = true;
            this.Button_Export.Click += new System.EventHandler(this.Button_Export_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(531, 216);
            this.Controls.Add(this.Button_Export);
            this.Controls.Add(this.PictureBox_Logo);
            this.Controls.Add(this.CheckBox_DigitLength);
            this.Controls.Add(this.CheckBox_Verbose);
            this.Controls.Add(this.RichTextBox_FileInfo);
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
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CommonDragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Button_Browse;
        private System.Windows.Forms.Button Button_Copy;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.RichTextBox RichTextBox_FileInfo;
        private System.Windows.Forms.CheckBox CheckBox_Verbose;
        private System.Windows.Forms.PictureBox PictureBox_Logo;
        private System.Windows.Forms.CheckBox CheckBox_DigitLength;
        private System.Windows.Forms.Button Button_Export;
    }
}

