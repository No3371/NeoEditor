using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeoEditor
{
    public partial class Loader : Form
    {
        public Loader()
        {
            InitializeComponent();
            StartingTimer.Start();
        }

        private void FadeoutTimer_Tick(object sender, EventArgs e)
        {
            this.Opacity -= 0.01;
            if (Opacity == 0) this.Dispose();
        }

        private void StartingTimer_Tick(object sender, EventArgs e)
        {
            FadeoutTimer.Start();
            StartingTimer.Dispose();
        }
    }
}
