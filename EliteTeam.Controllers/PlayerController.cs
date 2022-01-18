using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class PlayerController : IPlayerController
    {
        private IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void AddPlayer(Player player)
        {
            _playerRepository.addPlayer(player);
        }

        public List<Player> GetPlayers()
        {
            return _playerRepository.getAllPlayers();
        }

        public void RemovePlayer(string playerId)
        {
            _playerRepository.deletePlayer(playerId);
        }

        public void ShowAddNewPlayer(ICreatePlayerView inForm)
        {
            inForm.ShowModaless(this);
        }

        public void ShowPlayers(IPlayersListView inForm, IMainFormController mainFormController)
        {
            inForm.ShowModaless(this, mainFormController);
        }
    }
}
