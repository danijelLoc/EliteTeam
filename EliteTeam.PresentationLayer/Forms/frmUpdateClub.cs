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
    public partial class frmUpdateClub : Form, IUpdateClubView
    {
        private IClubController _clubController = null;
        private ClubDescriptor _club;
        private List<PlayerDescriptor> _clubSquad = new List<PlayerDescriptor>();
        private List<PlayerDescriptor> _freePlayers = new List<PlayerDescriptor>();
        public string ClubName { get { return textBoxName.Text; } }
        public string ShortClubName { get { return textBoxShortName.Text; } }
        public string ManagerName { get { return textBoxManager.Text; } }
        public string Tactic { get { return comboBoxTactic.SelectedItem.ToString(); } }
        public List<PlayerDescriptor> SquadPlayers { get { return _clubSquad; } }
        public frmUpdateClub()
        {
            InitializeComponent();
        }

        public void ShowModaless(IClubController clubController, ClubDescriptor club)
        {
            _club = club;
            _clubController = clubController;
            _clubSquad = clubController.GetClubSquad(club.Id);
            _freePlayers = clubController.GetFreeAgentPlayers();
            comboBoxTactic.Items.AddRange(_clubController.GetTacticOptions());
            UpdateLists();
            SetInitialElements();
            this.Show();
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void SetInitialElements()
        {
            textBoxManager.Text = _club.ClubManager;
            textBoxName.Text = _club.Name;
            textBoxShortName.Text = _club.ShortName;
            comboBoxTactic.SelectedIndex = comboBoxTactic.Items.IndexOf(_club.Tactic);

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

        private void RemoveClub()
        {
            _clubController.RemoveClub(this, _club.Id);
        }

        private void UpdateClub()
        {
            _clubController.UpdateClub(this, _club);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            ExceptionHandler.HandleBlock(RemoveClub, this);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ExceptionHandler.HandleBlock(UpdateClub, this);
        }
    }
}
