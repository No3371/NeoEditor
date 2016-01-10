namespace NeoEditor
{
    partial class MainForm
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
            this.CaptionBar = new System.Windows.Forms.Panel();
            this.LogoHolder = new System.Windows.Forms.PictureBox();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tabSidebar = new NeoEditor.TabSidebar();
            this.editBox1 = new NeoEditor.EditBox();
            this.CaptionBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoHolder)).BeginInit();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptionBar
            // 
            this.CaptionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.CaptionBar.Controls.Add(this.LogoHolder);
            this.CaptionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionBar.Location = new System.Drawing.Point(0, 0);
            this.CaptionBar.Name = "CaptionBar";
            this.CaptionBar.Size = new System.Drawing.Size(1280, 24);
            this.CaptionBar.TabIndex = 3;
            // 
            // LogoHolder
            // 
            this.LogoHolder.BackColor = System.Drawing.Color.Transparent;
            this.LogoHolder.Image = global::NeoEditor.Properties.Resources.Logo;
            this.LogoHolder.Location = new System.Drawing.Point(520, 0);
            this.LogoHolder.Name = "LogoHolder";
            this.LogoHolder.Size = new System.Drawing.Size(240, 24);
            this.LogoHolder.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoHolder.TabIndex = 3;
            this.LogoHolder.TabStop = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.tabSidebar);
            this.MainPanel.Controls.Add(this.editBox1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanel.Location = new System.Drawing.Point(0, 24);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(240, 696);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // tabSidebar
            // 
            this.tabSidebar.AutoScroll = true;
            this.tabSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.tabSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSidebar.Location = new System.Drawing.Point(0, 200);
            this.tabSidebar.Name = "tabSidebar";
            this.tabSidebar.Size = new System.Drawing.Size(240, 496);
            this.tabSidebar.TabIndex = 1;
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.editBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editBox1.Location = new System.Drawing.Point(0, 0);
            this.editBox1.Name = "editBox1";
            this.editBox1.Size = new System.Drawing.Size(240, 200);
            this.editBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.CaptionBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CaptionBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoHolder)).EndInit();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabSidebar tabSidebar;
        private System.Windows.Forms.Panel CaptionBar;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.PictureBox LogoHolder;
        private EditBox editBox1;
    }
}

