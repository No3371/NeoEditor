namespace NeoEditor
{
    partial class GhostButton
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
            this.components = new System.ComponentModel.Container();
            this.List_Icons = new System.Windows.Forms.ImageList(this.components);
            this.Icon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // List_Icons
            // 
            this.List_Icons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.List_Icons.ImageSize = new System.Drawing.Size(16, 16);
            this.List_Icons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Icon
            // 
            this.Icon.Location = new System.Drawing.Point(0, 0);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(120, 120);
            this.Icon.TabIndex = 0;
            this.Icon.TabStop = false;
            // 
            // GhostButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Icon);
            this.Name = "GhostButton";
            this.Size = new System.Drawing.Size(120, 120);
            this.Load += new System.EventHandler(this.GhostButton_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList List_Icons;
        private System.Windows.Forms.PictureBox Icon;

    }
}
