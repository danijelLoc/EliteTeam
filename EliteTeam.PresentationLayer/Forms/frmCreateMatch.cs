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
        IMainController _mainFormController = null;
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

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowModaless(IMatchController matchController, IMainController mainFormController)
        {
            _matchController = matchController;
            _mainFormController = mainFormController;
            foreach (var club in matchController.GetClubs())
            {
                comboBoxHome.Items.Add(club.Name);
                comboBoxAway.Items.Add(club.Name);
            }
            if (matchController.GetClubs().Count > 1)
            {
                comboBoxHome.SelectedIndex = 0;
                comboBoxAway.SelectedIndex = 1;
            }

            this.Show();
        }

        private void buttonSimulate_Click(object sender, EventArgs e)
        {
            _matchController.TryToCreateMatch(this, _mainFormController);
        }
    }
}
