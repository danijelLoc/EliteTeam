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
        private int matchLength = 90;
        private int matchTimeMinutes = 0;
        private int matchTimeSeconds = 0;
        private Timer matchTimer;
        private IMatchController _matchController;
        private IMatchSimulationController _matchSimulationController;
        public frmMatch()
        {
            InitializeComponent();
        }

        public void ShowModaless(IMatchController matchController, MatchSquad homeSquad, MatchSquad awaySquad)
        {
            _matchController = matchController;
            txtHomeClubName.Text = homeSquad.Club.Name;
            txtAwayClubName.Text = awaySquad.Club.Name;
            progressBarTime.Maximum = 90;
            progressBarTime.Value = 0;
            this.Show();
        }


        public void StartSimulation(IMatchSimulationController simulationController)
        {
            _matchSimulationController = simulationController;
            matchTimer = new Timer();
            matchTimer.Tick += new EventHandler(MinutePassed);
            matchTimer.Interval = 200;
            matchTimer.Start();
        }

        public void MinutePassed(object sender, EventArgs e)
        {
            AddTime(1, 0);
            txtMinutes.Text = matchTimeMinutes < 10 ? "0" + matchTimeMinutes.ToString() : matchTimeMinutes.ToString();
            txtSeconds.Text = matchTimeSeconds < 10 ? "0" + matchTimeSeconds.ToString() : matchTimeSeconds.ToString();
            progressBarTime.Value = matchTimeMinutes;
            _matchSimulationController.NextAction(this, matchTimeMinutes, matchTimeSeconds);

            // Pause at half time
            if (matchTimeMinutes == 45)
                Pause();

            // stop after 90 minutes
            if (matchTimeMinutes >= matchLength)
            {
                matchTimer.Stop();
                buttonResume.Enabled = false;
                buttonPause.Enabled = false;
                return;
            }

        }

        private void AddTime(int minutes, int seconds)
        {
            matchTimeMinutes += minutes;
            matchTimeSeconds += seconds;

            matchTimeMinutes += matchTimeSeconds / 60;
            matchTimeSeconds %= 60;
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

        public void UpdateMatchLog(string actionTime, string actionLog, string actionSummary)
        {
            ListViewItem item = new ListViewItem(actionTime);
            item.SubItems.Add(actionLog);
            item.SubItems.Add(actionSummary);
            listMatchLog.Items.Add(item);
            // color for goal and stopage
            if (actionSummary == "GOAL !!!")
                item.ForeColor = Color.Green;
            else if (actionSummary == "Half Time" || actionSummary == "Match End")
                item.ForeColor = Color.Orange;
            // scroll to bottom
            listMatchLog.Items[listMatchLog.Items.Count - 1].EnsureVisible();
        }

        private void Pause()
        {
            matchTimer.Stop();
            buttonResume.Enabled = true;
            buttonPause.Enabled = false;
        }

        private void Resume()
        {
            matchTimer.Start();
            buttonResume.Enabled = false;
            buttonPause.Enabled = true;
        }

        private void buttonResume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Pause();
        }


    }
}
