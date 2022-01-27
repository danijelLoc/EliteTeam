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
        public object[] getStatsRangeOptions();
        public object[] getPositionOptions();
        public void RemovePlayer(string playerId);
        public void ShowAddNewPlayer(ICreatePlayerView inView);
        public void TryToAddPlayer(ICreatePlayerView inView);
        public void ShowPlayers(IPlayersListView inView, IMainController mainController);
    }
}
