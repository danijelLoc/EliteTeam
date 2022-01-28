﻿using System;
using System.Collections.Generic;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class MainController : IMainController
    {
        private readonly IViewsFactory _viewsFactory = null;
        private readonly IPlayerRepository _playerRepository = null;
        private readonly IClubRepository _clubRepository = null;
        private readonly IMatchResultRepository _matchResultRepository = null;

        public MainController(IViewsFactory viewsFactory, IPlayerRepository playerRepository, IClubRepository clubRepository, IMatchResultRepository matchResultRepository)
        {
            _viewsFactory = viewsFactory;
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _matchResultRepository = matchResultRepository;
            CreateRandomData();
        }

        public void ShowMatchCreator()
        {
            var matchController = new MatchController(_matchResultRepository, _clubRepository, _playerRepository);
            var matchCreatorView = _viewsFactory.MatchCreatorView();
            matchController.ShowMatchCreator(matchCreatorView, this);
        }

        public void ShowMatch(MatchSquad homeSquad, MatchSquad awaySquad)
        {
            var matchController = new MatchController(_matchResultRepository, _clubRepository, _playerRepository);
            var matchView = _viewsFactory.MatchView();
            matchController.ShowMatch(matchView, homeSquad, awaySquad);
        }

        public void ShowPlayers()
        {
            var playerController = new PlayerController(_playerRepository, _clubRepository);
            var listView = _viewsFactory.PlayersListView();
            playerController.ShowPlayers(listView, this);
        }

        public void ShowCreatePlayer()
        {
            var playerController = new PlayerController(_playerRepository, _clubRepository);
            var createView = _viewsFactory.PlayerCreatorView();
            playerController.ShowAddNewPlayer(createView);
        }

        public void ShowUpdatePlayer(Player player)
        {
            var playerController = new PlayerController(_playerRepository, _clubRepository);
            var updateView = _viewsFactory.PlayerUpdaterView();
            playerController.ShowUpdatePlayer(updateView, player);
        }

        public void ShowClubs()
        {
            var clubController = new ClubController(_clubRepository, _playerRepository);
            var clubListView = _viewsFactory.ClubsListView();
            clubController.ShowClubs(clubListView, this);
        }

        public void ShowMatchResults()
        {
            var matchController = new MatchController(_matchResultRepository, _clubRepository, _playerRepository);
            var matchResultsView = _viewsFactory.MatchResultsListView();
            matchController.ShowMatchResults(matchResultsView, this);
        }

        public void ShowCreateClub()
        {
            var clubController = new ClubController(_clubRepository, _playerRepository);
            var createClubView = _viewsFactory.ClubCreatorView();
            clubController.ShowAddNewClub(createClubView);
        }

        public void ShowUpdateClub(Club club)
        {
            IClubController clubController = new ClubController(_clubRepository, _playerRepository);
            var updateClubView = _viewsFactory.ClubUpdaterView();
            clubController.ShowUpdateClub(updateClubView, club);
        }

        public void CreateRandomData()
        {
            List<Player> squad1 = PlayerFactory.GetRandomSquad();
            List<Player> squad2 = PlayerFactory.GetRandomSquad();
            List<Player> squad3 = PlayerFactory.GetRandomSquad();
            List<Player> squad4 = PlayerFactory.GetRandomSquad();
            List<Player> squad5 = PlayerFactory.GetRandomSquad();
            _playerRepository.addPlayers(squad1);
            _playerRepository.addPlayers(squad2);
            _playerRepository.addPlayers(squad3);
            _playerRepository.addPlayers(squad4);
            _playerRepository.addPlayers(squad5);
            Club dinamo = new Club("Dinamo", "DIN", "Željko Kopić", Tactic.possesion);
            Club hajduk = new Club("Hajduk", "HAJ", "Jens Gustafsson", Tactic.possesion);
            Club rijeka = new Club("Rijeka", "RIJ", "Filipo", Tactic.counterAttack);
            dinamo.SignPlayers(squad1.ConvertAll(x => x.Id));
            hajduk.SignPlayers(squad2.ConvertAll(x => x.Id));
            rijeka.SignPlayers(squad3.ConvertAll(x => x.Id));
            _playerRepository.playersSignedForClub(squad1.ConvertAll(x => x.Id), dinamo.Id);
            _playerRepository.playersSignedForClub(squad2.ConvertAll(x => x.Id), hajduk.Id);
            _playerRepository.playersSignedForClub(squad3.ConvertAll(x => x.Id), rijeka.Id);
            _clubRepository.addClub(dinamo);
            _clubRepository.addClub(hajduk);
            _clubRepository.addClub(rijeka);

            // IMatchSimulator matchSimulator = new MyMatchSimulator();
            // matchSimulator.Simulate(homeClub, awayClub, _playerRepository, null, null);
        }


    }
}
