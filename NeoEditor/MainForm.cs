using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NeoEditor
{
    public partial class MainForm : Form
    {

        public static bool debuging = true;
        public static Color Black87 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
        public static Color MainLimeGreen = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));
        FileManager fileManager;

        public Point PTnotification;

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

        //Drag on Logo
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public MainForm()
        {
            InitializeComponent();
            fileManager = new FileManager(this, this.tabSidebar, this.RTX);
            editBox.AssignRTX(this.RTX, this);
            this.DoubleBuffered = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabSidebar.Mainform = this;
            PTnotification = new Point(2, this.Height - 36);
            new Loader().Show(this);
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = RTXPanel.CreateGraphics())
            {
                Pen shadow = new Pen(Color.FromArgb(24, 24, 24), 1);
                g.DrawLine(shadow, 2, 0, 2, this.Height);
                g.DrawLine(shadow, 0, 2, this.Width, 2);
                shadow = new Pen(Color.FromArgb(28, 28, 28), 1);
                g.DrawLine(shadow, 2 + 1, 0, 2 + 1, this.Height);
                g.DrawLine(shadow, 0, 3, this.Width, 3);
                shadow = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(shadow, 2 + 2, 0, 2 + 2, this.Height);
                g.DrawLine(shadow, 0, 4, this.Width, 4);

                shadow.Dispose();

                Pen Reflect = new Pen(Color.FromArgb(48, 48, 48), 1);
                g.DrawLine(Reflect, 0, 0, 0, this.Height);
                g.DrawLine(Reflect, 0, 0, this.Width, 0);
                Reflect = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(Reflect, 1, 0, 1, this.Height);
                g.DrawLine(Reflect, 0, 1, this.Width, 1);

                Reflect.Dispose();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void CaptionBar_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = CaptionBar.CreateGraphics())
            {
                Pen Reflect = new Pen(Color.FromArgb(52, 52, 52), 1);
                Pen shadow = new Pen(Color.FromArgb(36, 36, 36), 1);
                g.DrawLine(Reflect, this.Width - 79, 0, this.Width - 79, CaptionBar.Height);
                g.DrawLine(shadow, this.Width - 80, 0, this.Width - 80, CaptionBar.Height);
                g.DrawLine(Reflect, this.Width - 81, 0, this.Width - 81, CaptionBar.Height);

                shadow.Dispose();
                Reflect.Dispose();

            }

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)

            {

                ReleaseCapture();

                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);

            }
        }

        private Keys lastKey = Keys.None;
        private void RTX_KeyDown(object sender, KeyEventArgs e)
        {
            lastKey = e.KeyData;
        }

        private void RTX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar))
            {
                //e.Handled = true;//prevent this key press
                Keys pressedKey = this.lastKey;

                ((FileManager.File)RTX.Tag).ifEdited = true;
                if (!((FileManager.File)RTX.Tag).Buttons.tab.Text.EndsWith("*Modified*")) ((FileManager.File)RTX.Tag).Buttons.tab.Text += "    *Modified*";

            }
        }

        private void tabSidebar_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                fileManager.LoadAFile(file);
            }
        }

        private void tabSidebar_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                // 允許拖拉動作繼續 (這時滑鼠游標應該會顯示 +)
                e.Effect = DragDropEffects.All;

            }
        }

        private void RTX_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left){
                if (RTX.SelectionFont != null)
                {
                    editBox.FontBox.Text = RTX.SelectionFont.Name;
                    editBox.FontSizeBox.Text = RTX.SelectionFont.Size.ToString();
                    editBox.StyleCheck(RTX.SelectionFont.Style);
                }
                else editBox.FontBox.Text = "(More then one)";
            }
        }
    }

}
