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
        void ShowModaless(IMatchController matchController, MatchSquad homeSquad, MatchSquad awaySquad);
    }
}
