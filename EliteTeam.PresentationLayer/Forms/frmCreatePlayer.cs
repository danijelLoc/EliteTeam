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
using EliteTeam.Model;

namespace EliteTeam.PresentationLayer
{
    public partial class frmCreatePlayer : Form, ICreatePlayerView
    {
        IPlayerController _playerController = null;
        public frmCreatePlayer()
        {
            InitializeComponent();
        }

        public void ShowModaless(IPlayerController playerController)
        {
            _playerController = playerController;

            this.Show();
        }

    }
}
