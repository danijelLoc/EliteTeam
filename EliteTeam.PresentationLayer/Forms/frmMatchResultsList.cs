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
    public partial class frmMatchResultsList : Form, IMatchResultsListView
    {
        private IMatchController _matchController = null;
        private IMainController _mainFormController = null;
        private List<MatchResult> _results = null;
        public frmMatchResultsList()
        {
            InitializeComponent();
        }

        public void ShowModaless(IMatchController matchController, IMainController mainController)
        {
            _matchController = matchController;
            _mainFormController = mainController;
            UpdateList();
            this.Show();
        }

        public void UpdateList()
        {
            _results = _matchController.GetMatchResults();
            for (int i = 0; i < _results.Count(); i++)
            {
                var result = _results[i];

                ListViewItem lvt = new ListViewItem(result.KickOffTime.ToString());
                lvt.SubItems.Add(result.HomeClubName);
                lvt.SubItems.Add(result.HomeClubGoals.ToString());
                lvt.SubItems.Add(result.AwayClubGoals.ToString());
                lvt.SubItems.Add(result.AwayClubName);

                listView1.Items.Add(lvt);
            }
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


    }
}
