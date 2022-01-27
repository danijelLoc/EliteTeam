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

        public void ShowAddNewPlayer(ICreatePlayerView inView)
        {
            inView.ShowModaless(this);
        }

        public void ShowPlayers(IPlayersListView inView, IMainController mainViewController)
        {
            inView.ShowModaless(this, mainViewController);
        }

        public void TryToAddPlayer(ICreatePlayerView inView)
        {
            try
            {
                Stats playerStats = new Stats();
                playerStats.Passing = inView.Passing;
                playerStats.Shooting = inView.Shooting;
                playerStats.Dribling = inView.Dribling;
                playerStats.Speed = inView.Speed;
                playerStats.Strenght = inView.Strenght;
                playerStats.Interceptions = inView.Interceptions;
                playerStats.Goalkeeping = inView.Goalkeeping;
                playerStats.Stamina = inView.Stamina;
                PlayerPosition position = (PlayerPosition)Enum.Parse(typeof(PlayerPosition), inView.Position);
                Player newPlayer = new Player(position, inView.PlayerName, inView.Age, inView.Country, playerStats);
                _playerRepository.addPlayer(newPlayer);
                inView.CloseView();
            }
            catch (Exception exc)
            {
                inView.ShowMessage(exc.Message);
            }
        }
    }
}
