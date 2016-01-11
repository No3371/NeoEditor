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
        List<string> SystemFonts = new List<string>();
        RichTextBox rtx;
        MainForm f;

        public EditBox()
        {
            InitializeComponent();
            
            FontFamily[] fontFamilies = new InstalledFontCollection().Families;
            foreach (FontFamily font in fontFamilies)
            {
                FontBox.Items.Add(font.Name);
                if(font.Name == "Times New Roman") FontBox.Text = "Times New Roman";
            }
        }

        public void AssignRTX(RichTextBox rtx, MainForm f)
        {
            this.rtx = rtx;
            this.f = f;
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
                f.ActiveControl = rtx;
            }
        }
    }
}
