using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoEditor
{
    public partial class Form1 : Form
    {
        //DropShadow
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void RTX_LocationChanged(object sender, EventArgs e)
        {
        }       

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen shadow = new Pen(Color.FromArgb(24, 24, 24), 3);
                g.DrawLine(shadow, tabSidebar.Width + 1, 4, tabSidebar.Width + 1, this.Height);
                shadow = new Pen(Color.FromArgb(26, 26, 26), 2);
                g.DrawLine(shadow, tabSidebar.Width + 1 + 3, 4, tabSidebar.Width + 1 + 3, this.Height);
                shadow = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(shadow, tabSidebar.Width + 1 + 5, 4, tabSidebar.Width + 1 + 5, this.Height);
                g.Dispose();
                shadow.Dispose();
            }
        }

    }


}
