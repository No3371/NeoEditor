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
    public partial class MainForm : Form
    {
        
        public static bool debuging = false;
        public static Color Black87 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
        public static Color MainLimeGreen = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
        FileManager fileManager;

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

        public MainForm()
        {
            InitializeComponent();
            fileManager = new FileManager(this.tabSidebar);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabSidebar.Mainform = this;
        }
        
        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = MainPanel.CreateGraphics())
            {
                Pen shadow = new Pen(Color.FromArgb(24, 24, 24), 1);
                g.DrawLine(shadow, tabSidebar.Width + 2, 0, tabSidebar.Width + 2, this.Height);
                g.DrawLine(shadow, tabSidebar.Width, 2, this.Width, 2);
                shadow = new Pen(Color.FromArgb(28, 28, 28), 1);
                g.DrawLine(shadow, tabSidebar.Width + 2 + 1, 0, tabSidebar.Width + 2 + 1, this.Height);
                g.DrawLine(shadow, tabSidebar.Width, 3, this.Width, 3);
                shadow = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(shadow, tabSidebar.Width + 2 + 1, 0, tabSidebar.Width + 2 + 1, this.Height);
                g.DrawLine(shadow, tabSidebar.Width, 4, this.Width, 4);

                shadow.Dispose();

                Pen Reflect = new Pen(Color.FromArgb(48, 48, 48), 1);
                g.DrawLine(Reflect, tabSidebar.Width, 0, tabSidebar.Width, this.Height);
                g.DrawLine(Reflect, tabSidebar.Width, 0, this.Width, 0);
                Reflect = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(Reflect, tabSidebar.Width+1, 0, tabSidebar.Width+1, this.Height);
                g.DrawLine(Reflect, tabSidebar.Width, 1, this.Width, 1);

                Reflect.Dispose();
                             
            }
        }
          

    }


}
