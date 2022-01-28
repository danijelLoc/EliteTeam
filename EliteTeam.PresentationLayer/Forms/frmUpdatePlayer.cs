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
    public partial class frmUpdatePlayer : Form, IUpdatePlayerView
    {
        IPlayerController _playerController = null;
        bool _resigned = false;
        Player _player = null;
        public frmUpdatePlayer()
        {
            InitializeComponent();
        }
        public bool Resigned { get { return _resigned; } }
        public string PlayerName { get { return textBoxName.Text; } }

        public int Passing { get { return int.Parse(comboBoxPassing.SelectedItem.ToString()); } }

        public int Shooting { get { return int.Parse(comboBoxShooting.SelectedItem.ToString()); } }

        public int Dribling { get { return int.Parse(comboBoxDribbling.SelectedItem.ToString()); } }

        public int Speed { get { return int.Parse(comboBoxSpeed.SelectedItem.ToString()); } }

        public int Strenght { get { return int.Parse(comboBoxStrenght.SelectedItem.ToString()); } }

        public int Interceptions { get { return int.Parse(comboBoxInterception.SelectedItem.ToString()); } }

        public int Goalkeeping { get { return int.Parse(comboBoxGoalkeeping.SelectedItem.ToString()); } }

        public int Stamina { get { return int.Parse(comboBoxStamina.SelectedItem.ToString()); } }

        public void ShowModaless(IPlayerController playerController, Player player)
        {
            _player = player;
            _playerController = playerController;
            var statsBoxes = new List<ComboBox>() { comboBoxPassing, comboBoxDribbling, comboBoxShooting, comboBoxSpeed, comboBoxStrenght, comboBoxInterception, comboBoxGoalkeeping, comboBoxStamina };
            foreach (var box in statsBoxes)
                box.Items.AddRange(_playerController.GetStatsRangeOptions());
            comboBoxPosition.Items.AddRange(_playerController.GetPositionOptions());
            SetInitialElements();
            this.Show();
        }

        private void SetInitialElements()
        {
            textBoxName.Text = _player.Name;
            textBoxAge.Text = _player.Age.ToString();
            textBoxCountry.Text = _player.Country;
            if (_player.ClubId != null)
            {
                labelClub.Text = "Plays for " + _playerController.PlayersClubName(_player.ClubId);
                buttonResign.Enabled = true;
            }
            var statsBoxes = new List<ComboBox>() { comboBoxPassing, comboBoxDribbling, comboBoxShooting, comboBoxSpeed, comboBoxStrenght, comboBoxInterception, comboBoxGoalkeeping, comboBoxStamina };
            var oldStats = new List<int>() { _player.Stats.Passing, _player.Stats.Dribling, _player.Stats.Shooting, _player.Stats.Speed, _player.Stats.Strenght, _player.Stats.Interceptions, _player.Stats.Goalkeeping, _player.Stats.Stamina };
            for (int i = 0; i < statsBoxes.Count; i++)
            {
                statsBoxes[i].SelectedIndex = statsBoxes[i].Items.IndexOf(oldStats[i]);
            }
            comboBoxPosition.SelectedIndex = comboBoxPosition.Items.IndexOf(_player.Position);
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void buttonResign_Click(object sender, EventArgs e)
        {
            _resigned = true;
            buttonResign.Enabled = false;
            labelClub.Text = "Player is going to resign";
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            _playerController.TryToUpdatePlayer(this, _player);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            _playerController.TryToDeletePlayer(this, _player);
        }
    }
}
