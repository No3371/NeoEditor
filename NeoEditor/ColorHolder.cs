using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoEditor
{
    public partial class ColorHolder : UserControl
    {
        Color holding;
        public Color Holding
        {
            get { return holding; }
            set { this.holding = value;}
        }

        public ColorHolder()
        {
            InitializeComponent();
            Holding = Color.Gray;
        }

        private void ColorHolder_Load(object sender, EventArgs e)
        {

        }

        private void ColorHolder_Paint(object sender, PaintEventArgs e)
        {
            using(Graphics g = this.CreateGraphics())
            {
                Brush b = new SolidBrush(Holding);
                Pen p = new Pen(Color.FromArgb(25, Holding), 6);
                RectangleF r = new RectangleF((float)(0.2 * this.Width), (float)(0.2 * this.Height), (float)(0.6 * this.Width), (float)(this.Height * 0.6));
                // Draw the button in the form of a circle
                g.FillEllipse(b, r);
                g.DrawEllipse(p, r);

                p = new Pen(Color.FromArgb(60, Holding), 4);
                g.DrawEllipse(p, r);

                p = new Pen(Color.FromArgb(80, Holding), 2);
                g.DrawEllipse(p, r);

                b.Dispose();
                p.Dispose();
            }
        }

        private void ColorHolder_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ColorDialog Colordlg = new ColorDialog();
                Colordlg.ShowDialog();
                Holding = Colordlg.Color;
                this.Refresh();
            }

        }
    }
}
