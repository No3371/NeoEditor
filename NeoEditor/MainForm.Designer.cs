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
            this.RTX = new System.Windows.Forms.RichTextBox();
            this.tabSidebar = new NeoEditor.TabSidebar();
            this.SuspendLayout();
            // 
            // RTX
            // 
            this.RTX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.RTX.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTX.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.RTX.ForeColor = System.Drawing.Color.White;
            this.RTX.Location = new System.Drawing.Point(249, 10);
            this.RTX.Margin = new System.Windows.Forms.Padding(6);
            this.RTX.Name = "RTX";
            this.RTX.Size = new System.Drawing.Size(1030, 700);
            this.RTX.TabIndex = 0;
            this.RTX.Text = "";
            // 
            // tabSidebar
            // 
            this.tabSidebar.AutoScroll = true;
            this.tabSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.tabSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabSidebar.Location = new System.Drawing.Point(0, 0);
            this.tabSidebar.Name = "tabSidebar";
            this.tabSidebar.Size = new System.Drawing.Size(240, 720);
            this.tabSidebar.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tabSidebar);
            this.Controls.Add(this.RTX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private TabSidebar tabSidebar;
        internal System.Windows.Forms.RichTextBox RTX;
    }
}

