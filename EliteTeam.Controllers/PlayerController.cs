﻿using System;
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
        private IClubRepository _clubRepository;

        public PlayerController(IPlayerRepository playerRepository, IClubRepository clubRepository)
        {
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
        }

        public List<PlayerDescriptor> GetPlayers()
        {
            return _playerRepository.getAllPlayers().ConvertAll(x => new PlayerDescriptor(x));
        }

        public object[] GetPositionOptions()
        {
            object[] positions = new object[4] { PlayerPosition.attacker, PlayerPosition.midfielder, PlayerPosition.defender, PlayerPosition.goalkeeper };
            return positions;
        }

        public object[] GetStatsRangeOptions()
        {
            object[] statsOptions = new object[5] { 1, 2, 3, 4, 5 };
            return statsOptions;
        }

        public string PlayersClubName(string clubId)
        {
            return _clubRepository.getClubByID(clubId).Name;
        }

        public void ShowAddNewPlayer(ICreatePlayerView inView)
        {
            inView.ShowModaless(this);
        }

        public void ShowPlayers(IPlayersListView inView, IMainController mainViewController)
        {
            // repository passed as ISubject
            inView.ShowModaless(this, mainViewController, _playerRepository);
        }

        public void ShowUpdatePlayer(IUpdatePlayerView inView, PlayerDescriptor player)
        {
            inView.ShowModaless(this, player);
        }

        public void AddPlayer(ICreatePlayerView inView)
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
            int age;
            if (!int.TryParse(inView.Age, out age))
            {
                throw new ArgumentException("Age must be integer");
            }
            Player newPlayer = new Player(position, inView.PlayerName, age, inView.Country, playerStats);
            newPlayer.PlayerAI = AIFactory.CreateAI(newPlayer.Position);
            _playerRepository.addPlayer(newPlayer);
            inView.CloseView();
        }

        public void DeletePlayer(IUpdatePlayerView inView, PlayerDescriptor playerToDelete)
        {
            // remove player from club
            if (playerToDelete.ClubId != null)
                _clubRepository.clubFiredPlayer(playerToDelete.Id, playerToDelete.ClubId);
            // delete player
            _playerRepository.deletePlayer(playerToDelete.Id);
            inView.CloseView();
        }

        public void UpdatePlayer(IUpdatePlayerView inView, PlayerDescriptor oldPlayerInfo)
        {
            Stats newStats = new Stats();
            newStats.Passing = inView.Passing;
            newStats.Shooting = inView.Shooting;
            newStats.Dribling = inView.Dribling;
            newStats.Speed = inView.Speed;
            newStats.Strenght = inView.Strenght;
            newStats.Interceptions = inView.Interceptions;
            newStats.Goalkeeping = inView.Goalkeeping;
            newStats.Stamina = inView.Stamina;
            _playerRepository.updatePlayerStatsAndName(oldPlayerInfo.Id, newStats, inView.PlayerName);
            if (inView.Resigned)
            {
                _clubRepository.clubFiredPlayer(oldPlayerInfo.Id, oldPlayerInfo.ClubId);
                _playerRepository.playerLeavesClub(oldPlayerInfo.Id);
            }
            inView.CloseView();
        }
    }
}
