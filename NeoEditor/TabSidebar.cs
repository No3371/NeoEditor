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
        Form1 MainForm;

        public TabSidebar(Form1 f)
        {
            InitializeComponent();
            MainForm = f;
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

        TabOrganizer tO = new TabOrganizer(); 



        private void refreshView(int newFocus)
        {
            tO.Tabs[tO.Focus].Buttons.outOfFocused();
            if (newFocus >= 0)
            {
                tO.Buttons[newFocus].Focused();
            }
            tO.Focus = newFocus;
            MainForm.Debug_RTX(tO.Focus, tO.Buttons.Count, tO.Buttons[tO.Focus].tab.Location.Y, tO.Buttons[tO.Focus].index);

        }        
        private void Organize()
        {
            for (int i = 0; i < tO.Tabs.Count; i++)
            {
                tO.Buttons[i].reAssign(i);
                tO.Buttons[i].reLocate();
            }
        }

        private class TabOrganizer
        {
            public int Focus;
            public List<FileTabs> Tabs;
            public FileTabs RefCurrent;
            TabSidebar ParentTS;

            public TabOrganizer(TabSidebar ParentTS){
                NewFile();
                this.Focus = 0;
                this.Tabs = new List<FileTabs>();
                this.RefCurrent = Tabs[0];
                this.ParentTS = ParentTS;
            }

            private void CloseAFile(int index)
            {
                //Decide the focus to move up or down
                //It should always move to the one above the tab which is being closed
                //Unless the closing one is the first tab

            }

            private void NewFile()
            {
                Tabs.Add(new FileTabs(false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString(), ParentTS));
            }


            private class Tab_Buttons
            {
                public Button tab;
                public Button close;
                TabOrganizer ParentTO;
                FileTabs AttachedFile;

                public Tab_Buttons(TabOrganizer ParentTO)
                {
                    this.tab = newTab();
                    this.close = newClosing();
                    this.ParentTO = ParentTO;
                }

                public void reLocate(int index)
                {
                    tab.Location = new System.Drawing.Point(0, index * 30);
                    close.Location = new System.Drawing.Point(tab.Width, index * 30);
                }

                //A (int) tag is assign to the buttons, which indicate the slot they currently located at
                public void AssignTag(int index)
                {
                    tab.Tag = index;
                    close.Tag = index;
                    reLocate(index);
                }


                private Button newTab()
                {
                    Button newBtn = new Button();
                    newBtn.BackColor = MainLimeGreen;
                    newBtn.FlatAppearance.BorderColor = MainLimeGreen;
                    newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    newBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                    newBtn.ForeColor = System.Drawing.Color.White;
                    newBtn.Location = new System.Drawing.Point(0, ParentTO.Tabs.Count * 30);
                    newBtn.Name = "Tab" + (ParentTO.Tabs.Count).ToString();
                    newBtn.Size = new System.Drawing.Size(ParentTO.ParentTS.Width - 30, 30);
                    newBtn.Text = "New File";
                    newBtn.UseVisualStyleBackColor = false;
                    newBtn.Click += Tab_Click;
                    newBtn.Tag = ParentTO.Tabs.Count;

                    ParentTO.ParentTS.Controls.Add(newBtn);

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
                    newBtn.Location = new System.Drawing.Point(ParentTO.ParentTS.Width - 30, ParentTO.Tabs.Count * 30);
                    newBtn.Name = "CloseTab" + (ParentTO.Tabs.Count).ToString();
                    newBtn.Size = new System.Drawing.Size(30, 30);
                    newBtn.UseVisualStyleBackColor = false;
                    newBtn.Click += Close_Click;
                    newBtn.MouseEnter += CloseTab_MouseEnter;
                    newBtn.MouseLeave += CloseTab_MouseLeave;
                    newBtn.BringToFront();
                    newBtn.Tag = ParentTO.Tabs.Count;

                    ParentTO.ParentTS.Controls.Add(newBtn);

                    return newBtn;
                }


                #region TabButton_Event
                private void Tab_Click(object sender, EventArgs e)
                {
                    Button tempbtn = (Button)sender;
                }

                private void Close_Click(object sender, EventArgs e)
                {
                    Button tempbtn = (Button)sender;
                    ParentTO.CloseAFile((int)tempbtn.Tag);
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

            private class FileTabs
            {
                bool ifEdited;
                string name;
                public bool ifFocused;
                string filePath;
                Tab_Buttons Buttons;
                TabSidebar tS;

                public FileTabs(bool ifedited, string name, bool iffocsed, string filepath, TabSidebar tS)
                {
                    this.ifEdited = ifedited;
                    this.ifFocused = iffocsed;
                    this.name = name;
                    this.filePath = filepath;
                    this.Buttons = new Tab_Buttons(newTab(), newClosing());
                    this.tS = tS;
                }

                public string getName()
                {
                    return name;
                }


            }

        }







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
