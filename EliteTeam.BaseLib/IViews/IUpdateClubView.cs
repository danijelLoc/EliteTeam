using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IUpdateClubView : IView
    {
        void ShowModaless(IClubController clubController, ClubDescriptor club);
        public string ClubName { get; }
        public string ShortClubName { get; }
        public string ManagerName { get; }
        public string Tactic { get; }
        public List<PlayerDescriptor> SquadPlayers { get; }

    }
}
