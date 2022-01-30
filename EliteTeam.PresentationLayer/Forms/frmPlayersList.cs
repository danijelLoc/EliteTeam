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
        private List<PlayerDescriptor> _listPlayers = null;
        private IMainController _mainFormController = null;
        private IPlayerController _playerController = null;
        private ISubject _playersListSubject;
        public frmPlayersList()
        {

            InitializeComponent();
        }

        private void PlayersList_Load(object sender, EventArgs e)
        {

        }

        public void ShowModaless(IPlayerController playerController, IMainController mainFormController, ISubject playersListSubject)
        {
            _mainFormController = mainFormController;
            _playerController = playerController;
            _playersListSubject = playersListSubject;
            playersListSubject.Subscribe(this);

            UpdateList();
            this.Show();
        }
        public void UpdateYourself()
        {
            UpdateList();
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void UpdateList()
        {
            listViewPlayers.Items.Clear();
            _listPlayers = _playerController.GetPlayers();
            for (int i = 0; i < _listPlayers.Count(); i++)
            {
                PlayerDescriptor player = _listPlayers[i];

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
                PlayerDescriptor player = _listPlayers[ind];

                _mainFormController.ShowUpdatePlayer(player);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _mainFormController.ShowCreatePlayer();
        }



    }
}
