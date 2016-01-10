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

        public MainForm Mainform;

        public TabSidebar()
        {
            InitializeComponent();
        }

        private void TabSidebar_Load(object sender, EventArgs e)
        {
            if (!MainForm.debuging) Debug_Info.Dispose();
        }

        #region Icon Add_Icons
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Icon_Add.Image = Properties.Resources.Icon_Add_Active;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Icon_Add.Image = Properties.Resources.Icon_Add;
        }


        #endregion

        public class Tab_Buttons
        {
            public Button tab;
            public Button close;
            FileManager FM;
            FileManager.File AttachedFile;
            TabSidebar TS;

            public Tab_Buttons(FileManager RootFM, FileManager.File AttachedFile, TabSidebar TS)
            {
                this.TS = TS;
                this.FM = RootFM;
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
                newBtn.BackColor = MainForm.MainLimeGreen;
                newBtn.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newBtn.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
                newBtn.ForeColor = System.Drawing.Color.White;
                newBtn.Location = new System.Drawing.Point(0, FM.Tabs.Count * 30);
                newBtn.Name = "Tab" + (FM.Tabs.Count).ToString();
                newBtn.Size = new System.Drawing.Size(TS.Width - 30, 30);
                newBtn.Text = "New File";
                newBtn.UseVisualStyleBackColor = false;
                newBtn.Click += Tab_Click;
                newBtn.Tag = this.AttachedFile;

                TS.Controls.Add(newBtn);

                return newBtn;
            }
            private Button newClosing()
            {
                Button newBtn = new Button();
                newBtn.BackColor = MainForm.MainLimeGreen;
                newBtn.BackgroundImage = Properties.Resources.Button_CloseTab;
                newBtn.BackgroundImageLayout = ImageLayout.Center;
                newBtn.FlatAppearance.MouseOverBackColor = MainForm.Black87;
                newBtn.FlatAppearance.MouseDownBackColor = MainForm.Black87;
                newBtn.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                newBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                newBtn.Location = new System.Drawing.Point(TS.Width - 30, FM.Tabs.Count * 30);
                newBtn.Name = "CloseTab" + (FM.Tabs.Count).ToString();
                newBtn.Size = new System.Drawing.Size(30, 30);
                newBtn.UseVisualStyleBackColor = false;
                newBtn.Click += Close_Click;
                newBtn.MouseEnter += CloseTab_MouseEnter;
                newBtn.MouseLeave += CloseTab_MouseLeave;
                newBtn.BringToFront();
                newBtn.Tag = this.AttachedFile;

                TS.Controls.Add(newBtn);

                return newBtn;
            }


            #region TabButton_Event
            private void Tab_Click(object sender, EventArgs e)
            {
                Button tempbtn = (Button)sender;
                FM.SwitchFocusTo(((FileManager.File)tempbtn.Tag));
            }

            private void Close_Click(object sender, EventArgs e)
            {
                Button tempbtn = (Button)sender;
                FM.CloseAFile((FileManager.File)tempbtn.Tag);
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
        public delegate void Icon_Add_Click(object sender, EventArgs e);
        public event Icon_Add_Click Icon_Add_Thrower;

        public void OnAddClicked(object sender, EventArgs e)
        {
            if (Icon_Add_Thrower != null) Icon_Add_Thrower(this, e);
        }
    }
}
