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
        private Timer matchTimer;
        private IMatchController _matchController;
        private IMatchSimulationController _matchSimulationController;

        public frmMatch()
        {
            InitializeComponent();
        }

        public void ShowModaless(IMatchSimulationController simulationController, IMatchController matchController, String homeClubName, String awayClubName)
        {
            _matchSimulationController = simulationController;
            _matchController = matchController;
            txtHomeClubName.Text = homeClubName;
            txtAwayClubName.Text = awayClubName;
            progressBarTime.Maximum = 90;
            progressBarTime.Value = 0;
            this.Show();
        }


        public void Start()
        {
            matchTimer = new Timer();
            matchTimer.Tick += new EventHandler(OnTimerTick);
            matchTimer.Interval = 200;
            matchTimer.Start();
            buttonResume.Text = "Resume";
            buttonPause.Enabled = true;
            buttonResume.Enabled = false;
        }
        public void Pause()
        {
            matchTimer.Stop();
            buttonResume.Enabled = true;
            buttonPause.Enabled = false;
        }

        public void Stop()
        {
            matchTimer.Stop();
            buttonResume.Enabled = false;
            buttonPause.Enabled = false;
        }

        public void Resume()
        {
            if (!_matchSimulationController.MatchHasStarted)
                Start();
            else
            {
                matchTimer.Start();
                buttonResume.Enabled = false;
                buttonPause.Enabled = true;
            }
        }

        public void OnTimerTick(object sender, EventArgs e)
        {
            _matchSimulationController.NextAction(this);
        }


        public void UpdateTime(int minutes, int seconds)
        {
            progressBarTime.Value = minutes;
            txtMinutes.Text = minutes < 10 ? "0" + minutes.ToString() : minutes.ToString();
            txtSeconds.Text = seconds < 10 ? "0" + seconds.ToString() : seconds.ToString();
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
            else if (actionSummary == "Half Time" || actionSummary == "Match End" || actionSummary == "Kickoff")
                item.ForeColor = Color.Blue;

            listMatchLog.Items[listMatchLog.Items.Count - 1].EnsureVisible();
        }



        private void buttonResume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            Pause();
        }
        public void CloseView()
        {
            this.Close();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void frmMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (matchTimer != null)
                matchTimer.Stop();
        }
    }
}
