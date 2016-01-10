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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TabSidebar));
            this.Debug_Info = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Icon_Save = new System.Windows.Forms.PictureBox();
            this.Icon_Add = new System.Windows.Forms.PictureBox();
            this.Icon_Load = new System.Windows.Forms.PictureBox();
            this.PlaceHolderLeft = new System.Windows.Forms.PictureBox();
            this.PlaceHolderRight = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Save)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderRight)).BeginInit();
            this.SuspendLayout();
            // 
            // Debug_Info
            // 
            this.Debug_Info.Location = new System.Drawing.Point(3, 257);
            this.Debug_Info.Name = "Debug_Info";
            this.Debug_Info.Size = new System.Drawing.Size(100, 96);
            this.Debug_Info.TabIndex = 2;
            this.Debug_Info.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PlaceHolderRight);
            this.panel1.Controls.Add(this.Icon_Save);
            this.panel1.Controls.Add(this.Icon_Add);
            this.panel1.Controls.Add(this.Icon_Load);
            this.panel1.Controls.Add(this.PlaceHolderLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 100);
            this.panel1.TabIndex = 3;
            // 
            // Icon_Save
            // 
            this.Icon_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Icon_Save.Dock = System.Windows.Forms.DockStyle.Left;
            this.Icon_Save.Image = ((System.Drawing.Image)(resources.GetObject("Icon_Save.Image")));
            this.Icon_Save.Location = new System.Drawing.Point(160, 0);
            this.Icon_Save.Name = "Icon_Save";
            this.Icon_Save.Size = new System.Drawing.Size(50, 100);
            this.Icon_Save.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Icon_Save.TabIndex = 1;
            this.Icon_Save.TabStop = false;
            this.Icon_Save.Tag = "Save";
            this.Icon_Save.Click += new System.EventHandler(this.OnIconClicked);
            this.Icon_Save.MouseEnter += new System.EventHandler(this.Save_MouseEnter);
            this.Icon_Save.MouseLeave += new System.EventHandler(this.Save_MouseLeave);
            // 
            // Icon_Add
            // 
            this.Icon_Add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Icon_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.Icon_Add.Image = ((System.Drawing.Image)(resources.GetObject("Icon_Add.Image")));
            this.Icon_Add.Location = new System.Drawing.Point(80, 0);
            this.Icon_Add.Name = "Icon_Add";
            this.Icon_Add.Size = new System.Drawing.Size(80, 100);
            this.Icon_Add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Icon_Add.TabIndex = 1;
            this.Icon_Add.TabStop = false;
            this.Icon_Add.Tag = "Add";
            this.Icon_Add.Click += new System.EventHandler(this.OnIconClicked);
            this.Icon_Add.MouseEnter += new System.EventHandler(this.Add_MouseEnter);
            this.Icon_Add.MouseLeave += new System.EventHandler(this.Add_MouseLeave);
            // 
            // Icon_Load
            // 
            this.Icon_Load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Icon_Load.Dock = System.Windows.Forms.DockStyle.Left;
            this.Icon_Load.Image = ((System.Drawing.Image)(resources.GetObject("Icon_Load.Image")));
            this.Icon_Load.Location = new System.Drawing.Point(30, 0);
            this.Icon_Load.Name = "Icon_Load";
            this.Icon_Load.Size = new System.Drawing.Size(50, 100);
            this.Icon_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Icon_Load.TabIndex = 2;
            this.Icon_Load.TabStop = false;
            this.Icon_Load.Tag = "Load";
            this.Icon_Load.Click += new System.EventHandler(this.OnIconClicked);
            this.Icon_Load.MouseEnter += new System.EventHandler(this.Load_MouseEnter);
            this.Icon_Load.MouseLeave += new System.EventHandler(this.Load_MouseLeave);
            // 
            // PlaceHolderLeft
            // 
            this.PlaceHolderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlaceHolderLeft.Location = new System.Drawing.Point(0, 0);
            this.PlaceHolderLeft.Name = "PlaceHolderLeft";
            this.PlaceHolderLeft.Size = new System.Drawing.Size(30, 100);
            this.PlaceHolderLeft.TabIndex = 3;
            this.PlaceHolderLeft.TabStop = false;
            // 
            // PlaceHolderRight
            // 
            this.PlaceHolderRight.Dock = System.Windows.Forms.DockStyle.Left;
            this.PlaceHolderRight.Location = new System.Drawing.Point(210, 0);
            this.PlaceHolderRight.Name = "PlaceHolderRight";
            this.PlaceHolderRight.Size = new System.Drawing.Size(30, 100);
            this.PlaceHolderRight.TabIndex = 4;
            this.PlaceHolderRight.TabStop = false;
            // 
            // TabSidebar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Debug_Info);
            this.Name = "TabSidebar";
            this.Size = new System.Drawing.Size(240, 472);
            this.Load += new System.EventHandler(this.TabSidebar_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Save)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Icon_Load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlaceHolderRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Icon_Add;
        public System.Windows.Forms.RichTextBox Debug_Info;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Icon_Save;
        private System.Windows.Forms.PictureBox Icon_Load;
        private System.Windows.Forms.PictureBox PlaceHolderRight;
        private System.Windows.Forms.PictureBox PlaceHolderLeft;
    }
}
