using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGN_DCS_Mod_Sync_App
{
    public partial class ucAutodetectAndOverride : UserControl
    {
        public ucAutodetectAndOverride()
        {
            InitializeComponent();
        }

        public bool AutodetectSelected()
        {
            return chkAutodetect.Checked;
        }

        public string GetValueInTextbox()
        {
            return txt.Text;
        }

        private void chkAutodetect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutodetect.Checked)
            {
                txt.ReadOnly = true;
                txt.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
            } else
            {
                txt.ReadOnly = false;
                txt.BackColor = Color.FromKnownColor(KnownColor.Window);
            }
        }
    }
}
