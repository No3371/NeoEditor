namespace NeoEditor
{
    partial class EditBox
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

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.FontBox = new System.Windows.Forms.ComboBox();
            this.FontSizeBox = new System.Windows.Forms.ComboBox();
            this.Button_Underline = new System.Windows.Forms.Button();
            this.Button_Italic = new System.Windows.Forms.Button();
            this.Button_Bold = new System.Windows.Forms.Button();
            this.colorHolder4 = new NeoEditor.ColorHolder();
            this.colorHolder5 = new NeoEditor.ColorHolder();
            this.colorHolder3 = new NeoEditor.ColorHolder();
            this.colorHolder2 = new NeoEditor.ColorHolder();
            this.colorHolder1 = new NeoEditor.ColorHolder();
            this.SuspendLayout();
            // 
            // FontBox
            // 
            this.FontBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.FontBox.DropDownHeight = 340;
            this.FontBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontBox.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FontBox.ForeColor = System.Drawing.Color.White;
            this.FontBox.FormattingEnabled = true;
            this.FontBox.IntegralHeight = false;
            this.FontBox.ItemHeight = 17;
            this.FontBox.Location = new System.Drawing.Point(8, 11);
            this.FontBox.MaxDropDownItems = 20;
            this.FontBox.Name = "FontBox";
            this.FontBox.Size = new System.Drawing.Size(150, 25);
            this.FontBox.Sorted = true;
            this.FontBox.TabIndex = 1;
            this.FontBox.SelectionChangeCommitted += new System.EventHandler(this.FontBox_SelectionChangeCommitted);
            // 
            // FontSizeBox
            // 
            this.FontSizeBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.FontSizeBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontSizeBox.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FontSizeBox.ForeColor = System.Drawing.Color.White;
            this.FontSizeBox.FormattingEnabled = true;
            this.FontSizeBox.Items.AddRange(new object[] {
            "6",
            "8",
            "10",
            "12",
            "14",
            "16",
            "18",
            "24",
            "32",
            "36",
            "42",
            "48",
            "56",
            "64",
            "72"});
            this.FontSizeBox.Location = new System.Drawing.Point(172, 11);
            this.FontSizeBox.Name = "FontSizeBox";
            this.FontSizeBox.Size = new System.Drawing.Size(60, 25);
            this.FontSizeBox.TabIndex = 1;
            this.FontSizeBox.Text = "12";
            this.FontSizeBox.SelectionChangeCommitted += new System.EventHandler(this.FontBox_SelectionChangeCommitted);
            // 
            // Button_Underline
            // 
            this.Button_Underline.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Button_Underline.BackgroundImage = global::NeoEditor.Properties.Resources.Font_Underline;
            this.Button_Underline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_Underline.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Underline.FlatAppearance.BorderSize = 0;
            this.Button_Underline.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Underline.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Underline.Location = new System.Drawing.Point(68, 45);
            this.Button_Underline.Name = "Button_Underline";
            this.Button_Underline.Size = new System.Drawing.Size(24, 24);
            this.Button_Underline.TabIndex = 2;
            this.Button_Underline.Tag = "Underline";
            this.Button_Underline.UseVisualStyleBackColor = false;
            this.Button_Underline.Click += new System.EventHandler(this.Style_Click);
            // 
            // Button_Italic
            // 
            this.Button_Italic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Button_Italic.BackgroundImage = global::NeoEditor.Properties.Resources.Font_Italic;
            this.Button_Italic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_Italic.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Italic.FlatAppearance.BorderSize = 0;
            this.Button_Italic.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Italic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Italic.Location = new System.Drawing.Point(38, 45);
            this.Button_Italic.Name = "Button_Italic";
            this.Button_Italic.Size = new System.Drawing.Size(24, 24);
            this.Button_Italic.TabIndex = 2;
            this.Button_Italic.Tag = "Italic";
            this.Button_Italic.UseVisualStyleBackColor = false;
            this.Button_Italic.Click += new System.EventHandler(this.Style_Click);
            // 
            // Button_Bold
            // 
            this.Button_Bold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Button_Bold.BackgroundImage = global::NeoEditor.Properties.Resources.Font_Bold;
            this.Button_Bold.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_Bold.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Bold.FlatAppearance.BorderSize = 0;
            this.Button_Bold.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
            this.Button_Bold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Bold.Location = new System.Drawing.Point(8, 45);
            this.Button_Bold.Name = "Button_Bold";
            this.Button_Bold.Size = new System.Drawing.Size(24, 24);
            this.Button_Bold.TabIndex = 2;
            this.Button_Bold.Tag = "Bold";
            this.Button_Bold.UseVisualStyleBackColor = false;
            this.Button_Bold.Click += new System.EventHandler(this.Style_Click);
            // 
            // colorHolder4
            // 
            this.colorHolder4.BackColor = System.Drawing.Color.Transparent;
            this.colorHolder4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorHolder4.Holding = System.Drawing.Color.Gray;
            this.colorHolder4.Location = new System.Drawing.Point(114, 44);
            this.colorHolder4.Name = "colorHolder4";
            this.colorHolder4.Size = new System.Drawing.Size(25, 25);
            this.colorHolder4.TabIndex = 3;
            this.colorHolder4.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorHolder_MouseClick);
            // 
            // colorHolder5
            // 
            this.colorHolder5.BackColor = System.Drawing.Color.Transparent;
            this.colorHolder5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorHolder5.Holding = System.Drawing.Color.Gray;
            this.colorHolder5.Location = new System.Drawing.Point(214, 48);
            this.colorHolder5.Name = "colorHolder5";
            this.colorHolder5.Size = new System.Drawing.Size(19, 19);
            this.colorHolder5.TabIndex = 3;
            this.colorHolder5.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorHolder_MouseClick);
            // 
            // colorHolder3
            // 
            this.colorHolder3.BackColor = System.Drawing.Color.Transparent;
            this.colorHolder3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorHolder3.Holding = System.Drawing.Color.Gray;
            this.colorHolder3.Location = new System.Drawing.Point(191, 48);
            this.colorHolder3.Name = "colorHolder3";
            this.colorHolder3.Size = new System.Drawing.Size(19, 19);
            this.colorHolder3.TabIndex = 3;
            this.colorHolder3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorHolder_MouseClick);
            // 
            // colorHolder2
            // 
            this.colorHolder2.BackColor = System.Drawing.Color.Transparent;
            this.colorHolder2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorHolder2.Holding = System.Drawing.Color.Gray;
            this.colorHolder2.Location = new System.Drawing.Point(167, 48);
            this.colorHolder2.Name = "colorHolder2";
            this.colorHolder2.Size = new System.Drawing.Size(19, 19);
            this.colorHolder2.TabIndex = 3;
            this.colorHolder2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorHolder_MouseClick);
            // 
            // colorHolder1
            // 
            this.colorHolder1.BackColor = System.Drawing.Color.Transparent;
            this.colorHolder1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.colorHolder1.Holding = System.Drawing.Color.Gray;
            this.colorHolder1.Location = new System.Drawing.Point(144, 48);
            this.colorHolder1.Name = "colorHolder1";
            this.colorHolder1.Size = new System.Drawing.Size(19, 19);
            this.colorHolder1.TabIndex = 3;
            this.colorHolder1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorHolder_MouseClick);
            // 
            // EditBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.colorHolder4);
            this.Controls.Add(this.colorHolder5);
            this.Controls.Add(this.colorHolder3);
            this.Controls.Add(this.colorHolder2);
            this.Controls.Add(this.colorHolder1);
            this.Controls.Add(this.Button_Underline);
            this.Controls.Add(this.Button_Italic);
            this.Controls.Add(this.Button_Bold);
            this.Controls.Add(this.FontSizeBox);
            this.Controls.Add(this.FontBox);
            this.Name = "EditBox";
            this.Size = new System.Drawing.Size(240, 80);
            this.Load += new System.EventHandler(this.EditBox_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditBox_Paint);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Button_Bold;
        private System.Windows.Forms.Button Button_Italic;
        private System.Windows.Forms.Button Button_Underline;
        private ColorHolder colorHolder1;
        private ColorHolder colorHolder4;
        private ColorHolder colorHolder2;
        private ColorHolder colorHolder3;
        private ColorHolder colorHolder5;
        public System.Windows.Forms.ComboBox FontBox;
        public System.Windows.Forms.ComboBox FontSizeBox;
    }
}
