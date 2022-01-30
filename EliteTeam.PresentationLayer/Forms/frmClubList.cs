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
    public partial class frmClubList : Form, IClubsListView
    {
        private IClubController _clubController = null;
        private IMainController _mainController = null;
        private List<ClubDescriptor> _clubs = null;
        private ISubject _clubsListSubject = null;

        public void UpdateYourself()
        {
            UpdateList();
        }

        public frmClubList()
        {
            InitializeComponent();
        }

        public void ShowModaless(IClubController clubController, IMainController mainController, ISubject clubsListSubject)
        {
            _clubController = clubController;
            _mainController = mainController;
            _clubsListSubject = clubsListSubject;
            clubsListSubject.Subscribe(this);
            UpdateList();
            this.Show();
        }

        public void UpdateList()
        {
            listView1.Items.Clear();
            _clubs = _clubController.GetClubs();
            for (int i = 0; i < _clubs.Count(); i++)
            {
                ClubDescriptor club = _clubs[i];

                ListViewItem lvt = new ListViewItem(club.Name);
                lvt.SubItems.Add(club.ShortName);
                lvt.SubItems.Add(club.ClubManager);

                listView1.Items.Add(lvt);
            }
        }

        public void CloseView()
        {
            _clubsListSubject.Unsubscribe(this);
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
                ClubDescriptor club = _clubs[ind];
                _mainController.ShowUpdateClub(club);
            }
        }


    }
}
