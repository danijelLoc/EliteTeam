using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface ICreateClubView : IView
    {
        void ShowModaless(IClubController clubController);
        public string ClubName { get; }
        public string ShortClubName { get; }
        public string ManagerName { get; }
        public string Tactic { get; }
        public List<PlayerDescriptor> SquadPlayers { get; }

    }
}
