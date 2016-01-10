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

        public void CloseAFile(File tab)
        {
            //Decide the focus to move up or down
            //It should always move to the one above the tab which is being closed
            //Unless the closing one is the first tab
            tab.Buttons.Dispose();
            Tabs.Remove(tab);
            foreach (File f in Tabs)
            {
                f.Buttons.reLocate(Tabs.IndexOf(f));
            }
            if (Focus > Tabs.Count - 1) Focus -= 1;
            SwitchFocusTo(Tabs[Focus]);


        }

        public void SwitchFocusTo(File tab)
        {
            Tabs[Focus].outOfFocused();
            tab.Focused();
            Focus = Tabs.IndexOf(tab);
            //rtx.Text = tab.content;

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

        public void SaveAFile(File f)
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
                    new NotificationBar(mainform, Color.OrangeRed, "Operation aborted. The file is not saved.");
                    return;
                }
            }
            rtx.SaveFile(f.filePath);
            f.content = rtx.Text;
            f.Saved();
            new NotificationBar(mainform, MainForm.MainLimeGreen, f.filePath + " Saved!");
        }

        public void LoadAFile()
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
                        new NotificationBar(mainform, Color.OrangeRed, "You have opened the file. Redirecting...");
                        SwitchFocusTo(loaded);
                        return;
                    }
                    }
                Tabs.Add(new File(openDlg.FileName.Substring(openDlg.FileName.LastIndexOf("\\") + 1), true, openDlg.FileName, this));
                SwitchFocusTo(Tabs[Tabs.Count - 1]);
            }
            else
            {
                new NotificationBar(mainform, Color.OrangeRed, "Operation aborted. The file will not be opened.");
                return;
            }
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
                return tempRTX.Text;
            }

            public void Focused()
            {
                ifFocused = true;
                buttons.tab.BackColor = MainForm.MainLimeGreen;
                buttons.tab.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                buttons.close.BackColor = MainForm.MainLimeGreen;
                buttons.close.FlatAppearance.BorderColor = MainForm.MainLimeGreen;
                ParentFM.rtx.Text = content;
                ParentFM.rtx.Tag = this;
            }

            public void outOfFocused()
            {
                ifFocused = false;
                buttons.tab.BackColor = MainForm.Black87;
                buttons.tab.FlatAppearance.BorderColor = MainForm.Black87;
                buttons.close.BackColor = MainForm.Black87;
                buttons.close.FlatAppearance.BorderColor = MainForm.Black87;
                content = ParentFM.rtx.Text;
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
