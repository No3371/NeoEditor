using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace NeoEditor
{
    public class FileManager
    {
        MainForm mainform;
        int Focus;
        public List<File> Tabs;
        public TabSidebar tabSidebar;
        System.Windows.Forms.RichTextBox rtx;

        public FileManager(MainForm f, TabSidebar TS, System.Windows.Forms.RichTextBox rtx)
        {
            this.mainform = f;
            this.rtx = rtx;

            this.tabSidebar = TS;
            tabSidebar.Icon_Click_Thrower += IconClicked;

            this.Tabs = new List<File>();
            Focus = 0;
            NewFile();            
        }

        private void IconClicked(object tag, EventArgs e)
        {
#pragma warning disable CS0252 // 可能誤用參考比較; 左端需要轉換
            if(tag == "Add") NewFile();
            else if (tag == "Load") LoadAFile();
            else if (tag == "Save") SaveAFile(Tabs[Focus]);
#pragma warning restore CS0252 // 可能誤用參考比較; 左端需要轉換
        }

        public bool CloseAFile(File tab)
        {
            //Ask to save if modified
            if(tab.ifEdited == true)
            {
                DialogResult dialogResult = MessageBox.Show("The file you just tried to close is modified and not yet saved, do you want to save it?", "Save?", MessageBoxButtons.YesNo); ;
                if (dialogResult == DialogResult.Yes)
                {
                    if(!SaveAFile(tab)) return false;
                }
            }
            if (Tabs.Count - 1 < 1) NewFile();

            if(Tabs.IndexOf(tab) <= Focus)
            {
                tab.Buttons.Dispose();
                Tabs.Remove(tab);
                SwitchFocusTo(Tabs[Focus - 1]);
            }
            else
            {
                tab.Buttons.Dispose();
                Tabs.Remove(tab);
            }

            foreach (File f in Tabs)
            {
                f.Buttons.reLocate(Tabs.IndexOf(f));
            }
            return true;


        }

        public void SwitchFocusTo(File tab)
        {
            if(Focus >= 0 && Focus < Tabs.Count) Tabs[Focus].outOfFocused();
            rtx.Clear();
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
            Tabs.Add(new File("New File", true, null, this));
            SwitchFocusTo(Tabs[Tabs.Count - 1]);
        }

        public bool SaveAFile(File f)
        {
            if (String.IsNullOrEmpty(f.filePath)){
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Title = "Save As";
                saveDlg.DefaultExt = "rtf";
                saveDlg.Filter = "RTF Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    f.filePath = saveDlg.FileName;
                }
                else
                {
                    new NotificationBar(mainform, "Bad", "Operation aborted. The file is not saved.");
                    return false;
                }
            }
            rtx.SaveFile(f.filePath);
            f.content = rtx.Text;
            f.Saved();
            new NotificationBar(mainform, "Good", f.filePath + " Saved!");
            return true;
        }

        public bool LoadAFile()
        {

            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.DefaultExt = "rtf";
            openDlg.Title = "Open";
            openDlg.Filter = "RTF Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if(openDlg.ShowDialog() == DialogResult.OK)
            {
                foreach (File loaded in Tabs)
                {
                    if (openDlg.FileName == loaded.filePath)
                    {
                        new NotificationBar(mainform, "Bad", "You have opened the file. Redirecting...");
                        SwitchFocusTo(loaded);
                        return false;
                    }
                    }
                Tabs.Add(new File(openDlg.FileName.Substring(openDlg.FileName.LastIndexOf("\\") + 1), true, openDlg.FileName, this));
                SwitchFocusTo(Tabs[Tabs.Count - 1]);
                return true;
            }
            else
            {
                new NotificationBar(mainform, "Bad", "Operation aborted. No file will be opened.");
                return false;
            }
        }
        public bool LoadAFile(string path)
        {
            foreach (File loaded in Tabs)
                {
                    if (path == loaded.filePath)
                    {
                        new NotificationBar(mainform, "Bad", "You have opened the file. Redirecting...");
                        SwitchFocusTo(loaded);
                        return false;
                    }
                }
                Tabs.Add(new File(path.Substring(path.LastIndexOf("\\") + 1), true, path, this));
                SwitchFocusTo(Tabs[Tabs.Count - 1]);
                return true;
        }


        public class File
        {
            public bool ifEdited;
            public string name;
            public bool ifFocused;
            public string filePath;
            private TabSidebar.Tab_Buttons buttons;
            public FileManager ParentFM;
            public string content;

            public TabSidebar.Tab_Buttons Buttons{
                get{ return buttons;}
                set{ buttons = value;}
            }

            public File(string name, bool iffocsed, string filepath, FileManager ParentFM)
            {
                this.ParentFM = ParentFM;
                this.ifEdited = false;
                this.ifFocused = iffocsed;
                this.name = name;
                this.filePath = filepath;
                this.buttons = new TabSidebar.Tab_Buttons(ParentFM, this, this.ParentFM.tabSidebar);
                if (String.IsNullOrEmpty(filePath)) this.content = "";
                else content = rtfReader(filePath);                
            }

            private string rtfReader(string path)
            {
                RichTextBox tempRTX = new RichTextBox();
                tempRTX.LoadFile(path);
                return tempRTX.Rtf;
            }

            public void Focused()
            {
                ifFocused = true;
                buttons.tab.BackColor = MainForm.MainLimeGreen;
                buttons.tab.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                buttons.close.BackColor = MainForm.MainLimeGreen;
                buttons.close.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                ParentFM.rtx.Rtf = content;
                ParentFM.rtx.Tag = this;
            }

            public void outOfFocused()
            {
                ifFocused = false;
                buttons.tab.BackColor = MainForm.Black87;
                buttons.tab.FlatAppearance.BorderColor = MainForm.Black87;
                buttons.close.BackColor = MainForm.Black87;
                buttons.close.FlatAppearance.BorderColor = MainForm.Black87;
                content = ParentFM.rtx.Rtf;
            }

            public void Saved()
            {
                ifEdited = false;
                name = filePath.Substring(filePath.LastIndexOf("\\")+1);
                buttons.tab.Text = name;
            }
        }
        
    }
}
