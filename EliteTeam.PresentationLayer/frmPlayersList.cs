using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EliteTeam.BaseLib;
using EliteTeam.Model;

namespace EliteTeam.PresentationLayer
{
    public partial class frmPlayersList : Form, IPlayersListView
    {
        private List<Player> _listPlayers = null;
        private IMainFormController _mainController = null;

        public frmPlayersList()
        {
            InitializeComponent();
        }

        private void PlayersList_Load(object sender, EventArgs e)
        {

        }

        public void ShowModaless(IMainFormController mainController, List<Player> listPlayers)
        {
            _mainController = mainController;
            _listPlayers = listPlayers;

            UpdateList();

            this.Show();
        }

        private void UpdateList()
        {
            for (int i = 0; i < _listPlayers.Count(); i++)
            {
                Player player = _listPlayers[i];

                string position = player.Position.ToString();
                string age = player.Age.ToString();

                ListViewItem lvt = new ListViewItem(player.Name);
                lvt.SubItems.Add(position);
                lvt.SubItems.Add(age);

                listViewPlayers.Items.Add(lvt);
            }
        }

        private void listViewPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewPlayers.SelectedItems[0] != null)
            {
                int ind = listViewPlayers.SelectedItems[0].Index;
                string playerId = _listPlayers[ind].Id;

                _mainController.EditPlayer(playerId);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _mainController.AddPlayer();
        }
    }
}
