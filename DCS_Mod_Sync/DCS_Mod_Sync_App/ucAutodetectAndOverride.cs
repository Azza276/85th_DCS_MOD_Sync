using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCS_Mod_Sync_App
{
    public partial class UcAutodetectAndOverride : UserControl
    {
        public UcAutodetectAndOverride()
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

        private void ChkAutodetect_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
