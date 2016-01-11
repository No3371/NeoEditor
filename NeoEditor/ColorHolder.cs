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
                Pen p = new Pen(Color.FromArgb(25, Holding), 4);
                // Draw the button in the form of a circle
                g.FillEllipse(b, (float)(0.15 * this.Width), (float)(0.15 * this.Height), (float)(0.7 * this.Width), (float)(this.Height * 0.7));
                g.DrawEllipse(p, (float)(0.15 * this.Width), (float)(0.15 * this.Height), (float)(0.7 * this.Width), (float)(this.Height * 0.7));

                p = new Pen(Color.FromArgb(50, Holding), 3);
                g.DrawEllipse(p, (float)(0.15 * this.Width), (float)(0.15 * this.Height), (float)(0.7 * this.Width), (float)(this.Height * 0.7));

                p = new Pen(Color.FromArgb(75, Holding), 2);
                g.DrawEllipse(p, (float)(0.15 * this.Width), (float)(0.15 * this.Height), (float)(0.7 * this.Width), (float)(this.Height * 0.7));

                p = new Pen(Color.FromArgb(85, Holding), 1);
                g.DrawEllipse(p, (float)(0.15 * this.Width), (float)(0.15 * this.Height), (float)(0.7 * this.Width), (float)(this.Height * 0.7));

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
