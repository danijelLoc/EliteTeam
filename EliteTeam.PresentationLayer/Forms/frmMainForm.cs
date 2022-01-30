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
    public partial class frmMainForm : Form, IMainView
    {
        private IMainController _mainController;
        public frmMainForm(IMainController mainFormController)
        {
            _mainController = mainFormController;
            InitializeComponent();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _mainController.ShowPlayers();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _mainController.ShowClubs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExceptionHandler.HandleBlock(_mainController.ShowMatchCreator, this);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _mainController.ShowMatchResults();
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
