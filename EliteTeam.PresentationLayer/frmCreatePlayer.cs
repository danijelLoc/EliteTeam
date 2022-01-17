using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EliteTeam.BaseLib;

namespace EliteTeam.PresentationLayer
{
    public partial class frmCreatePlayer : Form, ICreatePlayerView
    {
        public frmCreatePlayer()
        {
            InitializeComponent();
        }
        public bool ShowViewModal()
        {
            if (this.ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }
    }
}
