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
    public partial class frmCreateMatch : Form, ICreateMatchView
    {
        IMatchController _matchController = null;
        public frmCreateMatch()
        {
            InitializeComponent();
        }

        public string HomeClubName { get { return comboBoxHome.SelectedItem.ToString(); } }

        public string AwayClubName { get { return comboBoxAway.SelectedItem.ToString(); } }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowModaless(IMatchController matchController)
        {
            _matchController = matchController;
            this.Show();
        }
    }
}
