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
    public partial class frmMatch : Form, IMatchView
    {
        private int matchLenght = 90;
        private int matchTime = 0;
        private Timer matchTimer;
        public frmMatch()
        {
            InitializeComponent();
        }

        public void ShowModaless(IMatchController matchController, MatchSquad homeSquad, MatchSquad awaySquad)
        {
            txtHomeClubName.Text = homeSquad.Club.Name;
            txtAwayClubName.Text = awaySquad.Club.Name;
            txtTime.Text = matchTime.ToString() + ":00";
            this.Show();
            matchTimer = new Timer();
            matchTimer.Tick += new EventHandler(MinutePassed);
            matchTimer.Interval = 1000;
            matchTimer.Start();
        }

        public void MinutePassed(object sender, EventArgs e)
        {
            matchTime += 1;
            txtTime.Text = matchTime.ToString() + ":00";
            if (matchTime >= 90)
            {
                matchTimer.Stop();
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

        public void UpdateResult(int homeGoals, int awayGoals)
        {
            txtHomeGoals.Text = homeGoals.ToString();
            txtAwayGoals.Text = awayGoals.ToString();
        }
    }
}
