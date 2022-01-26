using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IMatchSimulationController
    {
        void Simulate(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad);
    }
}