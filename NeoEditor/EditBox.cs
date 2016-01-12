using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace NeoEditor
{
    public partial class EditBox : UserControl
    {
        FontFamily[] fontFamilies;
        RichTextBox rtx;
        MainForm mainform;

        public EditBox()
        {
            InitializeComponent();
            
            fontFamilies = new InstalledFontCollection().Families;
            FontBox.Items.Clear();
            foreach (FontFamily font in fontFamilies)
            {
                FontBox.Items.Add(font.Name);
            }
        }

        public void AssignRTX(RichTextBox rtx, MainForm f)
        {
            this.rtx = rtx;
            this.mainform = f;
        }

        private void EditBox_Load(object sender, EventArgs e)
        {

        }

        private void EditBox_Paint(object sender, PaintEventArgs e)
        {

            using (Graphics g = this.CreateGraphics())
            {
                Pen Reflect = new Pen(Color.FromArgb(48, 48, 48), 1);
                Pen shadow = new Pen(Color.FromArgb(28, 28, 28), 1);
                g.DrawLine(Reflect, 0, 0, this.Width, 0);
                g.DrawLine(shadow, 0, 1, this.Width, 1);
                g.DrawLine(Reflect, 0, 2, this.Width, 2);
                
                g.DrawLine(Reflect, 0, this.Height-5, this.Width, this.Height - 5);
                g.DrawLine(shadow, 0, this.Height - 4, this.Width, this.Height - 4);
                g.DrawLine(Reflect, 0, this.Height - 3, this.Width, this.Height - 3);

                shadow.Dispose();
                Reflect.Dispose();

            }
        }

        private void colorHolder_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                rtx.SelectionColor = ((ColorHolder)sender).Holding;
                mainform.ActiveControl = rtx;
            }
        }

        private void FontBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int size;
            
            if (FontBox.Items.Contains(FontBox.SelectedItem) && int.TryParse((string)FontSizeBox.SelectedItem, out size))
            {
                rtx.SelectionFont = new Font((string)FontBox.SelectedItem, size);
                mainform.ActiveControl = rtx;
            }
            else
            {
                new NotificationBar(mainform, "Bad", "The selected font is not found. This is a bug, please repot to us.");
            }
        }

        public void StyleCheck(FontStyle fS)
        {
            if (fS.HasFlag(FontStyle.Bold)){ this.Button_Bold.BackgroundImage = Properties.Resources.Font_Bold_Actived; }
            else this.Button_Bold.BackgroundImage = Properties.Resources.Font_Bold;
            if (fS.HasFlag(FontStyle.Italic)) { this.Button_Italic.BackgroundImage = Properties.Resources.Font_Italic_Actived; }
            else this.Button_Italic.BackgroundImage = Properties.Resources.Font_Italic;
            if (fS.HasFlag(FontStyle.Underline)) { this.Button_Underline.BackgroundImage = Properties.Resources.Font_Underline_Actived; }
            else this.Button_Underline.BackgroundImage = Properties.Resources.Font_Underline;
        }

        private void Style_Click(object sender, EventArgs e)
        {
#pragma warning disable CS0252 // 可能誤用參考比較; 左端需要轉換
            try {
                switch ((sender as Button).Tag as string)
                {
                    case "Bold":
                        rtx.SelectionFont = new Font(rtx.SelectionFont, rtx.SelectionFont.Style ^ FontStyle.Bold);
                        break;
                    case "Italic":
                        rtx.SelectionFont = new Font(rtx.SelectionFont, rtx.SelectionFont.Style ^ FontStyle.Italic);
                        break;
                    case "Underline":
                        rtx.SelectionFont = new Font(rtx.SelectionFont, rtx.SelectionFont.Style ^ FontStyle.Underline);
                        break;
                };
                StyleCheck(rtx.SelectionFont.Style);
                mainform.ActiveControl = rtx;
            }
            catch (Exception e2)
            {
                new NotificationBar(mainform, "Bad", "Style Changing failed. Are you trying to change style of texts in different fonts? This will be included in further updates.");
            }
#pragma warning restore CS0252 // 可能誤用參考比較; 左端需要轉換
        }
    }
}
