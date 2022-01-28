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
        public string PlayerName { get { return textBoxName.Text; } }
        public string Country { get { return textBoxCountry.Text; } }

        public string Age { get { return textBoxAge.Text; } }

        public string Position { get { return comboBoxPosition.SelectedItem.ToString(); } }

        public int Passing { get { return int.Parse(comboBoxPassing.SelectedItem.ToString()); } }

        public int Shooting { get { return int.Parse(comboBoxShooting.SelectedItem.ToString()); } }

        public int Dribling { get { return int.Parse(comboBoxDribbling.SelectedItem.ToString()); } }

        public int Speed { get { return int.Parse(comboBoxSpeed.SelectedItem.ToString()); } }

        public int Strenght { get { return int.Parse(comboBoxStrenght.SelectedItem.ToString()); } }

        public int Interceptions { get { return int.Parse(comboBoxInterception.SelectedItem.ToString()); } }

        public int Goalkeeping { get { return int.Parse(comboBoxGoalkeeping.SelectedItem.ToString()); } }

        public int Stamina { get { return int.Parse(comboBoxStamina.SelectedItem.ToString()); } }

        public void ShowModaless(IPlayerController playerController)
        {
            _playerController = playerController;
            var statsBoxes = new List<ComboBox>() { comboBoxPassing, comboBoxDribbling, comboBoxShooting, comboBoxSpeed, comboBoxStrenght, comboBoxInterception, comboBoxGoalkeeping, comboBoxStamina };
            foreach (var box in statsBoxes)
            {
                box.Items.AddRange(_playerController.GetStatsRangeOptions());
                box.SelectedIndex = 0;
            }
            comboBoxPosition.Items.AddRange(_playerController.GetPositionOptions());
            comboBoxPosition.SelectedIndex = 0;
            this.Show();
        }

        private void AddPlayer()
        {
            _playerController.AddPlayer(this);
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            ExceptionHandler.HandleBlock(AddPlayer, this);
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
