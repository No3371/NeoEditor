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
    public partial class NotificationBar : UserControl
    {
        public MainForm mainform;

        public NotificationBar(MainForm f, string type, string notification)
        {
            InitializeComponent();
            this.mainform = f;
            f.RTXPanel.Controls.Add(this);
            Location = this.mainform.PTnotification;
            this.BringToFront();

            if(type == "Good")
            {
                this.Icon.Image = Properties.Resources.Confirmation;
                this.BackColor = MainForm.MainLimeGreen;
            }else if(type == "Bad"){
            }

            sendNotification(notification);
        }
        
        public void sendNotification(string s)
        {
            label1.Text = s;
            this.Enabled = true;
            this.Visible = true;

            Y = 0;
            direction = 1;
            PopupTimer.Start();

        }        

        int Y;
        int direction = 1;
        private void PopupTimer_Tick(object sender, EventArgs e)
        {
            if (Y > -24) move(direction, 3);
            else if (Y > -34) move(direction, 2);
            else move(direction, 1);
            if(Y == -36)
            {
                move(direction, 1);
                PopupTimer.Stop();
                direction = -1;
                MoveOutTimer.Start();
            }
        }

        private void move(int direction, int speed)
        {
            speed *= -1;
            this.Location = new Point(this.Location.X, this.Location.Y + speed * direction);
            Y += speed * direction;
        }

        private void MoveOutTimer_Tick(object sender, EventArgs e)
        {
            if (MoveOutTimer.Interval != 30) MoveOutTimer.Interval = 30;
            if (Y == 0) this.Dispose();
            else if (Y > -2) move(direction, 1);
            else if (Y > -12) move(direction, 2);
            else move(direction, 3);

        }
    }
}
