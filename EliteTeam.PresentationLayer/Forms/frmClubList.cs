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
using EliteTeam.Model;

namespace EliteTeam.PresentationLayer
{
    public partial class frmClubList : Form, IClubsListView
    {
        private IClubController _clubController = null;
        private IMainController _mainController = null;
        private List<Club> _clubs = null;
        public frmClubList()
        {
            InitializeComponent();
        }

        public void ShowModaless(IClubController clubController, IMainController mainController)
        {
            _clubController = clubController;
            _mainController = mainController;
            UpdateList();
            this.Show();
        }

        public void UpdateList()
        {
            _clubs = _clubController.GetClubs();
            for (int i = 0; i < _clubs.Count(); i++)
            {
                Club club = _clubs[i];

                ListViewItem lvt = new ListViewItem(club.Name);
                lvt.SubItems.Add(club.ShortName);
                lvt.SubItems.Add(club.ClubManager);

                listView1.Items.Add(lvt);
            }
        }

        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            _mainController.ShowCreateClub();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems[0] != null)
            {
                int ind = listView1.SelectedItems[0].Index;
                Club club = _clubs[ind];
                _mainController.ShowUpdateClub(club);
            }
        }
    }
}
