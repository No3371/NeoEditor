namespace NeoEditor
{
    partial class TabSidebar
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
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Icon_Add = new System.Windows.Forms.PictureBox();
            this.Debug_Info = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Add)).BeginInit();
            this.SuspendLayout();
            // 
            // Icon_Add
            // 
            this.Icon_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Icon_Add.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Icon_Add.Image = global::NeoEditor.Properties.Resources.Icon_Add;
            this.Icon_Add.Location = new System.Drawing.Point(0, 359);
            this.Icon_Add.Name = "Icon_Add";
            this.Icon_Add.Size = new System.Drawing.Size(240, 113);
            this.Icon_Add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Icon_Add.TabIndex = 1;
            this.Icon_Add.TabStop = false;
            this.Icon_Add.Click += new System.EventHandler(this.OnAddClicked);
            this.Icon_Add.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.Icon_Add.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // Debug_Info
            // 
            this.Debug_Info.Location = new System.Drawing.Point(3, 257);
            this.Debug_Info.Name = "Debug_Info";
            this.Debug_Info.Size = new System.Drawing.Size(100, 96);
            this.Debug_Info.TabIndex = 2;
            this.Debug_Info.Text = "";
            // 
            // TabSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.Debug_Info);
            this.Controls.Add(this.Icon_Add);
            this.Name = "TabSidebar";
            this.Size = new System.Drawing.Size(240, 472);
            this.Load += new System.EventHandler(this.TabSidebar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Add)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Icon_Add;
        public System.Windows.Forms.RichTextBox Debug_Info;
    }
}
