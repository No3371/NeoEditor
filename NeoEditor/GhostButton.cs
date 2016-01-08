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
    public partial class GhostButton : UserControl
    {
        public GhostButton(string type)
        {
            InitializeComponent();

            if(type == "fonts") Icon.Image = Properties.Resources.Icon_Fonts;
        }

        private void GhostButton_Load(object sender, EventArgs e)
        {
            
        }
    }


}
