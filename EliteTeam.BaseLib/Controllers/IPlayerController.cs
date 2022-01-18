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
        public void AddPlayer(Player player);
        public void RemovePlayer(string playerId);
        public void ShowAddNewPlayer(ICreatePlayerView inForm);
        public void ShowPlayers(IPlayersListView inForm, IMainFormController mainFormController);
    }
}
