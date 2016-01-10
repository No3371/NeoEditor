using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoEditor
{
    public class FileManager
    {
        int Focus;
        public List<File> Tabs;
        public TabSidebar tabSidebar;

        public FileManager(TabSidebar TS)
        {

            this.tabSidebar = TS;
            tabSidebar.Icon_Add_Thrower += Icon_Add_Clicked;

            this.Tabs = new List<File>();
            Focus = 0;
            NewFile();            
        }

        private void Icon_Add_Clicked(object sender, EventArgs e)
        {
            NewFile();
        }

        public void CloseAFile(File tab)
        {
            //Decide the focus to move up or down
            //It should always move to the one above the tab which is being closed
            //Unless the closing one is the first tab
            tab.Buttons.Dispose();
            Tabs.Remove(tab);
            if (Focus > Tabs.Count - 1) Focus -= 1;
            foreach (File f in Tabs)
            {
                f.Buttons.reLocate(Tabs.IndexOf(f));
            }


        }

        public void SwitchFocusTo(File tab)
        {
            Tabs[Focus].outOfFocused();
            tab.Focused();
            Focus = Tabs.IndexOf(tab);
            if (MainForm.debuging) Debug();
        }

        private void Debug()
        {
            tabSidebar.Debug_Info.Text =
                "Focus: " + Focus + "\n" +
                "Count: " + Tabs.Count + "\n";
        }

        public void NewFile()
        {
            Tabs.Add(new File(false, "New File", true, System.IO.Path.GetTempPath() + Guid.NewGuid().ToString(), this));
            SwitchFocusTo(Tabs[Tabs.Count - 1]);
        }


        public class File
        {
            bool ifEdited;
            public string name;
            public bool ifFocused;
            string filePath;
            private TabSidebar.Tab_Buttons buttons;
            public FileManager ParentFM;
            string content;

            public TabSidebar.Tab_Buttons Buttons{
                get{ return buttons;}
                set{ buttons = value;}
            }

            public File(bool ifedited, string name, bool iffocsed, string filepath, FileManager ParentFM)
            {
                this.ParentFM = ParentFM;
                this.ifEdited = ifedited;
                this.ifFocused = iffocsed;
                this.name = name;
                this.filePath = filepath;
                this.buttons = new TabSidebar.Tab_Buttons(ParentFM, this, this.ParentFM.tabSidebar);
                this.content = "";
            }

            public void Focused()
            {
                ifFocused = true;
                buttons.tab.BackColor = MainForm.MainLimeGreen;
                buttons.tab.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                buttons.close.BackColor = MainForm.MainLimeGreen;
                buttons.close.FlatAppearance.BorderColor = MainForm.MainLimeGreen;


            }

            public void outOfFocused()
            {
                ifFocused = false;
                buttons.tab.BackColor = MainForm.Black87;
                buttons.tab.FlatAppearance.BorderColor = MainForm.Black87;
                buttons.close.BackColor = MainForm.Black87;
                buttons.close.FlatAppearance.BorderColor = MainForm.Black87;
            }


        }
        
    }
}
