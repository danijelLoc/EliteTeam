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
    public partial class frmCreateClub : Form, ICreateClubView
    {
        private IClubController _clubController = null;
        private List<Player> _clubSquad = new List<Player>();
        private List<Player> _freePlayers = new List<Player>();
        public frmCreateClub()
        {
            InitializeComponent();
        }

        public string ClubName { get { return textBoxName.Text; } }

        public string ShortClubName { get { return textBoxShortName.Text; } }

        public string ManagerName { get { return textBoxManager.Text; } }

        public string Tactic { get { return comboBoxTactic.SelectedItem.ToString(); } }

        public List<Player> SquadPlayers { get { return _clubSquad; } }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ShowModaless(IClubController clubController)
        {
            _clubController = clubController;
            _freePlayers = clubController.GetFreeAgentPlayers();
            comboBoxTactic.Items.AddRange(_clubController.getTacticOptions());
            UpdateLists();
            this.Show();
        }

        private void UpdateLists()
        {
            listViewSquadPlayers.Items.Clear();
            listViewFreePlayers.Items.Clear();
            for (int i = 0; i < _clubSquad.Count(); i++)
            {
                Player player = _clubSquad[i];

                string position = player.Position.ToString();
                string age = player.Age.ToString();

                ListViewItem lvt = new ListViewItem(player.Name);
                lvt.SubItems.Add(position);
                lvt.SubItems.Add(age);

                listViewSquadPlayers.Items.Add(lvt);
            }
            for (int i = 0; i < _freePlayers.Count(); i++)
            {
                Player player = _freePlayers[i];

                string position = player.Position.ToString();
                string age = player.Age.ToString();

                ListViewItem lvt = new ListViewItem(player.Name);
                lvt.SubItems.Add(position);
                lvt.SubItems.Add(age);

                listViewFreePlayers.Items.Add(lvt);
            }
        }


        private void buttonCreate_Click(object sender, EventArgs e)
        {
            _clubController.TryToAddClub(this);
        }

        private void listViewFreePlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFreePlayers.SelectedItems[0] != null)
            {
                int ind = listViewFreePlayers.SelectedItems[0].Index;
                Player player = _freePlayers[ind];
                _freePlayers.Remove(player);
                _clubSquad.Add(player);
                UpdateLists();
            }
        }

        private void listViewSquadPlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewSquadPlayers.SelectedItems[0] != null)
            {
                int ind = listViewSquadPlayers.SelectedItems[0].Index;
                Player player = _clubSquad[ind];
                _clubSquad.Remove(player);
                _freePlayers.Add(player);
                UpdateLists();
            }
        }
    }
}
