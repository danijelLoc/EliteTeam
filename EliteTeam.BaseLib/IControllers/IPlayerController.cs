using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IPlayerController
    {
        public List<Player> GetPlayers();
        public string PlayersClubName(string clubId);
        public object[] GetStatsRangeOptions();
        public object[] GetPositionOptions();
        public void ShowAddNewPlayer(ICreatePlayerView inView);
        public void ShowUpdatePlayer(IUpdatePlayerView inView, Player player);
        public void TryToAddPlayer(ICreatePlayerView inView);
        public void TryToDeletePlayer(IUpdatePlayerView inView, Player playerToDelete);
        public void TryToUpdatePlayer(IUpdatePlayerView inView, Player oldPlayerInfo);
        public void ShowPlayers(IPlayersListView inView, IMainController mainController);
    }
}
