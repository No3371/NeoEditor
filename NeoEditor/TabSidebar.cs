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
            AddATab();
        }

        #region Icon Add_Events
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
            AddATab();
        }

        #endregion

        public static Color Black87 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
        public static Color MainLimeGreen = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));

        TabOrganizer tO = new TabOrganizer(new List<FileTabs>(), new List<Tab_Buttons>()); 

        private Button newTab()
        {
            Button newBtn = new Button();
            newBtn.BackColor = MainLimeGreen;
            newBtn.FlatAppearance.BorderColor = MainLimeGreen;
            newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            newBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            newBtn.ForeColor = System.Drawing.Color.White;
            newBtn.Location = new System.Drawing.Point(0, tO.Tabs.Count * 30 + 2);
            newBtn.Name = "Tab" + (tO.Tabs.Count).ToString();
            newBtn.Size = new System.Drawing.Size(this.Width-30, 30);
            newBtn.Text = "New File";
            newBtn.UseVisualStyleBackColor = false;
            newBtn.Click += Tab_Click;
            newBtn.Tag = tO.Tabs.Count;

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
            newBtn.Location = new System.Drawing.Point(this.Left + this.Width - 30, this.Top + tO.Tabs.Count * 30 + 2);
            newBtn.Name = "CloseTab" + (tO.Tabs.Count).ToString();
            newBtn.Size = new System.Drawing.Size(30, 30);
            newBtn.UseVisualStyleBackColor = false;
            newBtn.Click += Close_Click;
            newBtn.MouseEnter += CloseTab_MouseEnter;
            newBtn.MouseLeave += CloseTab_MouseLeave;
            newBtn.BringToFront();
            newBtn.Tag = tO.Tabs.Count;

            this.Controls.Add(newBtn);

            return newBtn;
        }

        private void refreshView(int newFocus)
        {
            Organize();
            if (tO.Buttons.Count-1>=tO.Focus)
            {
                tO.Buttons[tO.Focus].outOfFocused();
            }
            if (newFocus >= 0)
            {
                tO.Buttons[newFocus].Focused();
            }
            tO.Focus = newFocus;

        }
        
        private void Organize()
        {
            for (int i = 0; i < tO.Tabs.Count; i++)
            {
                tO.Buttons[i].reAssign(i, tO.Tabs[i].getName());
                tO.Buttons[i].reLocate();
            }
        }

        struct TabOrganizer
        {
            public int Focus;
            public List<FileTabs> Tabs;
            public List<Tab_Buttons> Buttons;

            public TabOrganizer(List<FileTabs> Tabs, List<Tab_Buttons> Buttons){
                this.Focus = 0;
                this.Tabs = Tabs;
                this.Buttons = Buttons;
            }
        }

        struct Tab_Buttons
        {
            public int index;
            public Button tab;
            public Button close;

            public Tab_Buttons(Button tab, Button close, int index)
            {
                this.index = index;
                this.tab = tab;
                this.close = close;
            }

            public void reLocate()
            {
                tab.Location = new System.Drawing.Point(0, index * 30 + 2);
                close.Location = new System.Drawing.Point(tab.Width, index * 30 + 2);
            }

            public void reAssign(int index, string text){
                this.index = index;
                tab.Text = text;
                tab.Tag = index;
                close.Tag = index;
            }

            public void disposing()
            {
                tab.Dispose();
                close.Dispose();
            }

            public void Focused()
            {
                tab.BackColor = MainLimeGreen;
                tab.FlatAppearance.BorderColor = MainLimeGreen;
                close.BackColor = MainLimeGreen;
                close.FlatAppearance.BorderColor = MainLimeGreen;
                
            }

            public void outOfFocused()
            {
                tab.BackColor = Black87;
                tab.FlatAppearance.BorderColor = Black87;
                close.BackColor = Black87;
                close.FlatAppearance.BorderColor = Black87;
            }

            


        }

        struct FileTabs
        {
            bool ifEdited;
            string name;
            bool ifFocused;
            string filePath;

            public FileTabs(bool ifedited, string name, bool iffocsed, string filepath){
                this.ifEdited = ifedited;
                this.ifFocused = iffocsed;
                this.name = name;
                this.filePath = filepath;
            }

            public string getName(){
                return name;
            }
        }

        private void AddATab()
        {
            tO.Buttons.Add(new Tab_Buttons(newTab(), newClosing(), tO.Tabs.Count));
            tO.Tabs.Add(new FileTabs(false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString()));
            refreshView(tO.Tabs.Count - 1);
        }

        private void CloseATab(int index)
        {
            if (index == tO.Focus)
            {
                tO.Focus -= 1;
            }
            if (index <= tO.Focus)
            {
                tO.Focus -= 1;
            }
            tO.Buttons[index].disposing();
            tO.Tabs.RemoveAt(index);
            tO.Buttons.RemoveAt(index);
            refreshView(tO.Focus);
        }

        #region TabButton_Event
        private void Tab_Click(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender; 
            refreshView((int)tempbtn.Tag);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Button tempbtn = (Button)sender;
            CloseATab((int)tempbtn.Tag);
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
