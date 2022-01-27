﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EliteTeam.BaseLib;
using EliteTeam.Controllers;

namespace EliteTeam.PresentationLayer
{
    public partial class frmMainForm : Form, IMainView
    {
        private MainController _mainController;
        public frmMainForm(MainController mainFormController)
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
            _mainController.ShowMatchCreator();
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
