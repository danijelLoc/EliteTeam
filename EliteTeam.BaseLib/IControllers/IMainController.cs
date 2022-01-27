using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IMainController
    {
        public void ShowMatchCreator();
        public void ShowMatch(MatchSquad homeSquad, MatchSquad awaySquad);
        public void ShowPlayers();
        public void ShowClubs();
        public void AddPlayer();
        public void AddClub();
        void EditPlayer(string playerId);
        void EditClub(string playerId);
    }
}
