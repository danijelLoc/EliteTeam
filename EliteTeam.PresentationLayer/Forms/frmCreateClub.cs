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
        private List<PlayerDescriptor> _clubSquad = new List<PlayerDescriptor>();
        private List<PlayerDescriptor> _freePlayers = new List<PlayerDescriptor>();
        public frmCreateClub()
        {
            InitializeComponent();
        }

        public string ClubName { get { return textBoxName.Text; } }

        public string ShortClubName { get { return textBoxShortName.Text; } }

        public string ManagerName { get { return textBoxManager.Text; } }

        public string Tactic { get { return comboBoxTactic.SelectedItem.ToString(); } }

        public List<PlayerDescriptor> SquadPlayers { get { return _clubSquad; } }

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
            comboBoxTactic.Items.AddRange(_clubController.GetTacticOptions());
            comboBoxTactic.SelectedIndex = 0;
            UpdateLists();
            this.Show();
        }

        private void UpdateLists()
        {
            listViewSquadPlayers.Items.Clear();
            listViewFreePlayers.Items.Clear();
            for (int i = 0; i < _clubSquad.Count(); i++)
            {
                PlayerDescriptor player = _clubSquad[i];

                string position = player.Position.ToString();
                string age = player.Age.ToString();

                ListViewItem lvt = new ListViewItem(player.Name);
                lvt.SubItems.Add(position);
                lvt.SubItems.Add(age);

                listViewSquadPlayers.Items.Add(lvt);
            }
            for (int i = 0; i < _freePlayers.Count(); i++)
            {
                PlayerDescriptor player = _freePlayers[i];

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
            ExceptionHandler.HandleBlock(AddClub, this);
        }

        private void AddClub()
        {
            _clubController.AddClub(this);
        }

        private void listViewFreePlayers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewFreePlayers.SelectedItems[0] != null)
            {
                int ind = listViewFreePlayers.SelectedItems[0].Index;
                PlayerDescriptor player = _freePlayers[ind];
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
                PlayerDescriptor player = _clubSquad[ind];
                _clubSquad.Remove(player);
                _freePlayers.Add(player);
                UpdateLists();
            }
        }
    }
}
