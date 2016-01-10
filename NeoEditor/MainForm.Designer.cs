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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.RTX = new System.Windows.Forms.RichTextBox();
            this.RTXPanel = new System.Windows.Forms.Panel();
            this.Pic_Logo = new System.Windows.Forms.PictureBox();
            this.Button_Min = new System.Windows.Forms.Button();
            this.Button_Exit = new System.Windows.Forms.Button();
            this.tabSidebar = new NeoEditor.TabSidebar();
            this.editBox1 = new NeoEditor.EditBox();
            this.CaptionBar.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.RTXPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptionBar
            // 
            this.CaptionBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.CaptionBar.Controls.Add(this.Pic_Logo);
            this.CaptionBar.Controls.Add(this.Button_Min);
            this.CaptionBar.Controls.Add(this.Button_Exit);
            this.CaptionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionBar.Location = new System.Drawing.Point(0, 0);
            this.CaptionBar.Name = "CaptionBar";
            this.CaptionBar.Size = new System.Drawing.Size(1280, 24);
            this.CaptionBar.TabIndex = 3;
            this.CaptionBar.Paint += new System.Windows.Forms.PaintEventHandler(this.CaptionBar_Paint);
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
            // RTX
            // 
            this.RTX.AcceptsTab = true;
            this.RTX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.RTX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTX.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTX.ForeColor = System.Drawing.Color.Silver;
            this.RTX.Location = new System.Drawing.Point(10, 10);
            this.RTX.Name = "RTX";
            this.RTX.Size = new System.Drawing.Size(1020, 676);
            this.RTX.TabIndex = 4;
            this.RTX.Text = "";
            this.RTX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RTX_KeyDown);
            this.RTX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RTX_KeyPress);
            // 
            // RTXPanel
            // 
            this.RTXPanel.Controls.Add(this.RTX);
            this.RTXPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.RTXPanel.Location = new System.Drawing.Point(240, 24);
            this.RTXPanel.Name = "RTXPanel";
            this.RTXPanel.Size = new System.Drawing.Size(1040, 696);
            this.RTXPanel.TabIndex = 5;
            this.RTXPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // Pic_Logo
            // 
            this.Pic_Logo.Image = global::NeoEditor.Properties.Resources.Caption_Logo;
            this.Pic_Logo.Location = new System.Drawing.Point(0, 0);
            this.Pic_Logo.Name = "Pic_Logo";
            this.Pic_Logo.Size = new System.Drawing.Size(240, 24);
            this.Pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Pic_Logo.TabIndex = 5;
            this.Pic_Logo.TabStop = false;
            this.Pic_Logo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // Button_Min
            // 
            this.Button_Min.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_Min.FlatAppearance.BorderSize = 0;
            this.Button_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Min.Image = global::NeoEditor.Properties.Resources.Button_Minimize;
            this.Button_Min.Location = new System.Drawing.Point(1232, 0);
            this.Button_Min.Name = "Button_Min";
            this.Button_Min.Size = new System.Drawing.Size(24, 24);
            this.Button_Min.TabIndex = 4;
            this.Button_Min.UseVisualStyleBackColor = true;
            this.Button_Min.Click += new System.EventHandler(this.button2_Click);
            // 
            // Button_Exit
            // 
            this.Button_Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Button_Exit.FlatAppearance.BorderSize = 0;
            this.Button_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Exit.Image = global::NeoEditor.Properties.Resources.Button_CloseTab;
            this.Button_Exit.Location = new System.Drawing.Point(1256, 0);
            this.Button_Exit.Name = "Button_Exit";
            this.Button_Exit.Size = new System.Drawing.Size(24, 24);
            this.Button_Exit.TabIndex = 4;
            this.Button_Exit.UseVisualStyleBackColor = true;
            this.Button_Exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabSidebar
            // 
            this.tabSidebar.AllowDrop = true;
            this.tabSidebar.AutoScroll = true;
            this.tabSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.tabSidebar.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabSidebar.Location = new System.Drawing.Point(0, 100);
            this.tabSidebar.Name = "tabSidebar";
            this.tabSidebar.Size = new System.Drawing.Size(240, 596);
            this.tabSidebar.TabIndex = 1;
            this.tabSidebar.DragDrop += new System.Windows.Forms.DragEventHandler(this.tabSidebar_DragDrop);
            this.tabSidebar.DragEnter += new System.Windows.Forms.DragEventHandler(this.tabSidebar_DragEnter);
            // 
            // editBox1
            // 
            this.editBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.editBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editBox1.Location = new System.Drawing.Point(0, 0);
            this.editBox1.Name = "editBox1";
            this.editBox1.Size = new System.Drawing.Size(240, 100);
            this.editBox1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.RTXPanel);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.CaptionBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CaptionBar.ResumeLayout(false);
            this.CaptionBar.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.RTXPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabSidebar tabSidebar;
        private System.Windows.Forms.Panel CaptionBar;
        private System.Windows.Forms.Panel MainPanel;
        private EditBox editBox1;
        private System.Windows.Forms.Button Button_Exit;
        private System.Windows.Forms.RichTextBox RTX;
        private System.Windows.Forms.Button Button_Min;
        private System.Windows.Forms.PictureBox Pic_Logo;
        public System.Windows.Forms.Panel RTXPanel;
    }
}

