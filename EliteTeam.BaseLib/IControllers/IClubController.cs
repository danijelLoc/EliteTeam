using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IClubController
    {
        public List<Club> GetClubs();
        public List<Player> GetClubSquad(string clubId);
        public List<Player> GetFreeAgentPlayers();
        public object[] GetTacticOptions();
        public void ShowAddNewClub(ICreateClubView inView);
        public void ShowUpdateClub(IUpdateClubView inView, Club club);
        public void ShowClubs(IClubsListView inView, IMainController mainController);
        public void TryToRemoveClub(IUpdateClubView inView, string clubId);
        public void TryToAddClub(ICreateClubView inView);
        public void TryToUpdateClub(IUpdateClubView inView, Club oldClubInfo);
    }
}
