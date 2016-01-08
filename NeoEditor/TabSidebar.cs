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
    public partial class TabSidebar : UserControl
    {

        public TabSidebar()
        {
            InitializeComponent();
        }

        private void TabSidebar_Load(object sender, EventArgs e)
        {
            index[1] += 1;
            Tabs.Add(new FileTabs(index[1] + 1, false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString(), newTab(), newClosing()));
            refreshView(index[1]);

        }

        Color Black87 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
        Color MainLimeGreen = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));

        #region Icon Add_Event
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Icon_Add.Image = Properties.Resources.Icon_Add_Active;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Icon_Add.Image = Properties.Resources.Icon_Add;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            index[1] += 1;
            Tabs.Add(new FileTabs(index[1] + 1, false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString(), newTab(), newClosing()));
            refreshView(index[1]);
        }

        #endregion

        List<FileTabs> Tabs = new List<FileTabs>();


        private Button newTab()
        {
            Button newBtn = new Button();
            newBtn.BackColor = MainLimeGreen;
            newBtn.FlatAppearance.BorderColor = MainLimeGreen;
            newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            newBtn.ForeColor = System.Drawing.Color.White;
            newBtn.Location = new System.Drawing.Point(0, index[1] * 30 + 2);
            newBtn.Name = "Tab" + (index[1]).ToString();
            newBtn.Size = new System.Drawing.Size(this.Width-30, 30);
            newBtn.Text = "New File";
            newBtn.UseVisualStyleBackColor = false;
            newBtn.Click += Tab_Click;

            this.Controls.Add(newBtn);

            return newBtn;
        }

        private Button newClosing()
        {
            Button newBtn = new Button();
            newBtn.BackColor = MainLimeGreen;
            newBtn.BackgroundImage = Properties.Resources.Button_CloseTab;
            newBtn.BackgroundImageLayout = ImageLayout.Center;
            newBtn.FlatAppearance.MouseOverBackColor = Black87;
            newBtn.FlatAppearance.MouseDownBackColor = Black87;
            newBtn.FlatAppearance.BorderColor = MainLimeGreen;
            newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newBtn.Location = new System.Drawing.Point(this.Left + this.Width - 30, this.Top + index[1] * 30 + 2);
            newBtn.Name = "CloseTab" + (index[1]).ToString();
            newBtn.Size = new System.Drawing.Size(30, 30);
            newBtn.UseVisualStyleBackColor = false;
            newBtn.Click += Close_Click;
            newBtn.MouseEnter += CloseTab_MouseEnter;
            newBtn.MouseLeave += CloseTab_MouseLeave;
            newBtn.BringToFront();

            this.Controls.Add(newBtn);

            return newBtn;
        }

        private void refreshView(int newFocus)
        {
            if (index[0] > -1)
            {
                Tabs[index[0]].tab.BackColor = Black87;
                Tabs[index[0]].tab.FlatAppearance.BorderColor = Black87;
                Tabs[index[0]].close.BackColor = Black87;
                Tabs[index[0]].close.FlatAppearance.BorderColor = Black87;
            }
            Tabs[newFocus].tab.BackColor = MainLimeGreen;
            Tabs[newFocus].close.BackColor = MainLimeGreen;
            Tabs[newFocus].tab.FlatAppearance.BorderColor = MainLimeGreen;
            Tabs[newFocus].close.FlatAppearance.BorderColor = MainLimeGreen;
            index[0] = newFocus;

        }

        int[] index = new int[2] { -1, -1 };
        

        struct FileTabs
        {

            public int index;
            bool ifEdited;
            string name;
            bool ifFocused;
            string filePath;
            public Button tab;
            public Button close;

            public FileTabs(int index, bool ifedited, string name, bool iffocsed, string filepath, Button tab, Button close){
                this.index = index;
                this.ifEdited = ifedited;
                this.ifFocused = iffocsed;
                this.name = name;
                this.filePath = filepath;
                this.tab = tab;
                this.close = close;
            }

            public void ATabClosed(){
                index -= 1;
            }
        }

        private void CloseATab(int index)
        {
            this.index[1] -= 1;
            if(this.index[0] == index) refreshView(this.index[0] - 1);
            foreach(FileTabs ft in Tabs){
                ft.ATabClosed();
                ft.tab.Name = "Tab" + ft.index;
                ft.close.Name = "CloseTab" + ft.index;
            }
            Tabs[index].tab.Dispose();
            Tabs[index].close.Dispose();
            Tabs.RemoveAt(index);
        }

        #region TabButton_Event
        private void Tab_Click(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender; 
            int index = int.Parse(tempbtn.Name.Replace("Tab", ""));
            refreshView(index);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender;
            int index = int.Parse(tempbtn.Name.Replace("CloseTab", ""));
            CloseATab(index);
        }

        private void CloseTab_MouseEnter(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender;
            tempbtn.BackgroundImage = Properties.Resources.Button_CloseTab_MouseOver;
        }

        private void CloseTab_MouseLeave(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender;
            tempbtn.BackgroundImage = Properties.Resources.Button_CloseTab;
        }

        #endregion

        private void TabSidebar_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics g = this.CreateGraphics())
            {
                Pen shadow = new Pen(Color.FromArgb(48, 48, 48), 2);
                g.DrawLine(shadow, this.Width - 2, 0, this.Width-2, this.Height);
                shadow = new Pen(Color.FromArgb(30, 30, 30), 1);
                g.DrawLine(shadow, this.Width, 0, this.Width, this.Height);
                g.Dispose();
                shadow.Dispose();
            }
        }
    }
}
