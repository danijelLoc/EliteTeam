using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IMatchSimulationController
    {
        void CreateSimulation(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad);
        bool MatchHasStarted { get; }
        void NextAction(IMatchView matchView);
    }
}