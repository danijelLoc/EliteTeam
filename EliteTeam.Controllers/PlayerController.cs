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

        public List<Player> GetPlayers()
        {
            return _playerRepository.getAllPlayers();
        }

        public object[] getPositionOptions()
        {
            object[] positions = new object[4] { PlayerPosition.attacker, PlayerPosition.midfielder, PlayerPosition.defender, PlayerPosition.goalkeeper };
            return positions;
        }

        public object[] getStatsRangeOptions()
        {
            object[] statsOptions = new object[5] { 1, 2, 3, 4, 5 };
            return statsOptions;
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

        public void TryToAddPlayer(ICreatePlayerView inForm)
        {
            Stats playerStats = new Stats();
            playerStats.Passing = inForm.Passing;
            playerStats.Shooting = inForm.Shooting;
            playerStats.Dribling = inForm.Dribling;
            playerStats.Speed = inForm.Speed;
            playerStats.Strenght = inForm.Strenght;
            playerStats.Interceptions = inForm.Interceptions;
            playerStats.Goalkeeping = inForm.Goalkeeping;
            playerStats.Stamina = inForm.Stamina;
            PlayerPosition position = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), inForm.Position);
            Player newPlayer = new Player(position, inForm.PlayerName, inForm.Age, inForm.Country, playerStats);
            _playerRepository.addPlayer(newPlayer);
            inForm.CloseView();
        }
    }
}
