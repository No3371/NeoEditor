namespace NeoEditor
{
    partial class NotificationBar
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.Icon = new System.Windows.Forms.PictureBox();
            this.PopupTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveOutTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(72, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is a notification.";
            // 
            // Icon
            // 
            this.Icon.Image = global::NeoEditor.Properties.Resources.Alert;
            this.Icon.Location = new System.Drawing.Point(0, 0);
            this.Icon.Name = "Icon";
            this.Icon.Size = new System.Drawing.Size(60, 36);
            this.Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Icon.TabIndex = 0;
            this.Icon.TabStop = false;
            // 
            // PopupTimer
            // 
            this.PopupTimer.Interval = 30;
            this.PopupTimer.Tick += new System.EventHandler(this.PopupTimer_Tick);
            // 
            // MoveOutTimer
            // 
            this.MoveOutTimer.Interval = 2000;
            this.MoveOutTimer.Tick += new System.EventHandler(this.MoveOutTimer_Tick);
            // 
            // NotificationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OrangeRed;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Icon);
            this.Name = "NotificationBar";
            this.Size = new System.Drawing.Size(1040, 36);
            ((System.ComponentModel.ISupportInitialize)(this.Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Icon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer PopupTimer;
        private System.Windows.Forms.Timer MoveOutTimer;
    }
}
