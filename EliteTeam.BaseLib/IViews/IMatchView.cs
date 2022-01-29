using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IMatchView : IView
    {
        void ShowModaless(IMatchSimulationController simulationController, IMatchController matchController, String homeClubName, String awayClubName);
        void Start();
        void Resume();
        void Pause();
        void Stop();
        void UpdateResult(int homeGoals, int awayGoals);
        void UpdateTime(int minutes, int seconds);
        void UpdateMatchLog(string actionTime, string actionLog, string actionSummary);
    }
}
