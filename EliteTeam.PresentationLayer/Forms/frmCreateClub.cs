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
    public partial class frmCreateClub : Form, ICreateClubView
    {
        private IClubController _clubController = null;
        public frmCreateClub()
        {
            InitializeComponent();
        }

        public string ClubName { get { return textBoxName.Text; } }

        public string ShortClubName { get { return textBoxShortName.Text; } }

        public string ManagerName { get { return textBoxManager.Text; } }

        public string Tactic { get { return comboBoxTactic.SelectedItem.ToString(); } }

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
            comboBoxTactic.Items.AddRange(_clubController.getTacticOptions());
            this.Show();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _clubController.TryToAddClub(this);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
