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
    internal partial class TabSidebar : UserControl
    {
        const bool debuging = true;

        public MainForm Mainform;
        TabOrganizer tO;

        public TabSidebar()
        {
            InitializeComponent();
            tO = new TabOrganizer(this);
        }

        private void TabSidebar_Load(object sender, EventArgs e)
        {
            if (!debuging) Debug_Info.Dispose();
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
            tO.NewFile();
        }

        #endregion

        public static Color Black87 = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
        public static Color MainLimeGreen = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(231)))), ((int)(((byte)(118)))));

         
        internal class TabOrganizer
        {
            int Focus;
            public List<FileTab> Tabs;
            TabSidebar ParentTS;

            public TabOrganizer(TabSidebar ParentTS){
                this.ParentTS = ParentTS;
                this.Tabs = new List<FileTab>();
                Focus = 0;
                NewFile();
            }

            public void CloseAFile(FileTab tab)
            {
                //Decide the focus to move up or down
                //It should always move to the one above the tab which is being closed
                //Unless the closing one is the first tab
                tab.Buttons.Dispose();
                Tabs.Remove(tab);
                if (Focus > Tabs.Count - 1) Focus -= 1;
                foreach (FileTab f in Tabs)
                {
                    f.Buttons.reLocate(Tabs.IndexOf(f));
                }
                

            }

            public void SwitchFocusTo(FileTab tab)
            {
                Tabs[Focus].outOfFocused();
                tab.Focused();
                Focus = Tabs.IndexOf(tab);
                if (TabSidebar.debuging) Debug();
            }

            private void Debug()
            {
                ParentTS.Debug_Info.Text =
                    "Focus: " + Focus + "\n" +
                    "Count: " + Tabs.Count + "\n";
            }

            public void NewFile()
            {
                Tabs.Add(new FileTab(false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString(), this));
                SwitchFocusTo(Tabs[Tabs.Count-1]);
            }
            
            internal class Tab_Buttons
            {
                public Button tab;
                public Button close;
                TabOrganizer RootTO;
                FileTab AttachedFile;

                public Tab_Buttons(TabOrganizer RootTO, FileTab AttachedFile)
                {
                    this.RootTO = RootTO;
                    this.AttachedFile = AttachedFile;
                    this.tab = newTab();
                    this.close = newClosing();
                }

                public void reLocate(int index)
                {
                    tab.Location = new System.Drawing.Point(0, index * 30);
                    close.Location = new System.Drawing.Point(tab.Width, index * 30);
                }

                private Button newTab()
                {
                    Button newBtn = new Button();
                    newBtn.BackColor = MainLimeGreen;
                    newBtn.FlatAppearance.BorderColor = MainLimeGreen;
                    newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    newBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    newBtn.ForeColor = System.Drawing.Color.White;
                    newBtn.Location = new System.Drawing.Point(0, RootTO.Tabs.Count * 30);
                    newBtn.Name = "Tab" + (RootTO.Tabs.Count).ToString();
                    newBtn.Size = new System.Drawing.Size(RootTO.ParentTS.Width - 30, 30);
                    newBtn.Text = "New File";
                    newBtn.UseVisualStyleBackColor = false;
                    newBtn.Click += Tab_Click;
                    newBtn.Tag = this.AttachedFile;

                    RootTO.ParentTS.Controls.Add(newBtn);

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
                    newBtn.Location = new System.Drawing.Point(RootTO.ParentTS.Width - 30, RootTO.Tabs.Count * 30);
                    newBtn.Name = "CloseTab" + (RootTO.Tabs.Count).ToString();
                    newBtn.Size = new System.Drawing.Size(30, 30);
                    newBtn.UseVisualStyleBackColor = false;
                    newBtn.Click += Close_Click;
                    newBtn.MouseEnter += CloseTab_MouseEnter;
                    newBtn.MouseLeave += CloseTab_MouseLeave;
                    newBtn.BringToFront();
                    newBtn.Tag = this.AttachedFile;

                    RootTO.ParentTS.Controls.Add(newBtn);

                    return newBtn;
                }


                #region TabButton_Event
                private void Tab_Click(object sender, EventArgs e)
                {
                    Button tempbtn = (Button)sender;
                    RootTO.SwitchFocusTo(((FileTab)tempbtn.Tag));
                }

                private void Close_Click(object sender, EventArgs e)
                {
                    Button tempbtn = (Button)sender;
                    RootTO.CloseAFile((FileTab)tempbtn.Tag);
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

                public void Dispose()
                {
                    tab.Dispose();
                    close.Dispose();
                }
            }

            internal class FileTab
            {
                bool ifEdited;
                public string name;
                public bool ifFocused;
                string filePath;
                public Tab_Buttons Buttons;
                public TabOrganizer ParentTO;
                string content;

                public FileTab(bool ifedited, string name, bool iffocsed, string filepath, TabOrganizer ParentTO)
                {
                    this.ifEdited = ifedited;
                    this.ifFocused = iffocsed;
                    this.name = name;
                    this.filePath = filepath;
                    this.Buttons = new Tab_Buttons(ParentTO, this);
                    this.ParentTO = ParentTO;
                    this.content = "";
                }

                public void Focused()
                {
                    ifFocused = true;
                    Buttons.tab.BackColor = MainLimeGreen;
                    Buttons.tab.FlatAppearance.BorderColor = MainLimeGreen;
                    Buttons.close.BackColor = MainLimeGreen;
                    Buttons.close.FlatAppearance.BorderColor = MainLimeGreen;

                }

                public void outOfFocused()
                {
                    ifFocused = false;
                    Buttons.tab.BackColor = Black87;
                    Buttons.tab.FlatAppearance.BorderColor = Black87;
                    Buttons.close.BackColor = Black87;
                    Buttons.close.FlatAppearance.BorderColor = Black87;
                }


            }

        }

        /*internal class Communicator
        {
            MainForm RootF;
            TabSidebar ParentTS;

            public Communicator(MainForm f, TabSidebar ParentTS)
            {
                this.RootF = f;
                this.ParentTS = ParentTS;
            }

            public void a(string a){
                RootF.RTX.Text = a;
        }
         

            
        }*/
        
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
