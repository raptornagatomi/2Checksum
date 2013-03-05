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
            this.listView1 = new System.Windows.Forms.ListView();
            this.Panel_Icon = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Button_Browse
            // 
            this.Button_Browse.Image = ((System.Drawing.Image)(resources.GetObject("Button_Browse.Image")));
            this.Button_Browse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Browse.Location = new System.Drawing.Point(298, 81);
            this.Button_Browse.Name = "Button_Browse";
            this.Button_Browse.Size = new System.Drawing.Size(109, 39);
            this.Button_Browse.TabIndex = 0;
            this.Button_Browse.Text = "Browse";
            this.Button_Browse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Browse.UseVisualStyleBackColor = true;
            // 
            // Button_Copy
            // 
            this.Button_Copy.Image = ((System.Drawing.Image)(resources.GetObject("Button_Copy.Image")));
            this.Button_Copy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Copy.Location = new System.Drawing.Point(298, 126);
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
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 36);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(280, 129);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Panel_Icon
            // 
            this.Panel_Icon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel_Icon.BackgroundImage")));
            this.Panel_Icon.Location = new System.Drawing.Point(356, 12);
            this.Panel_Icon.Name = "Panel_Icon";
            this.Panel_Icon.Size = new System.Drawing.Size(48, 48);
            this.Panel_Icon.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 178);
            this.Controls.Add(this.Panel_Icon);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.RadioButton_8digitChecksum);
            this.Controls.Add(this.RadioButton_4digitChecksum);
            this.Controls.Add(this.Button_Copy);
            this.Controls.Add(this.Button_Browse);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Panel Panel_Icon;
    }
}

