using System;
using System.Collections.Generic;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class MainFormController : IMainFormController
    {
        private readonly IWindowFormsFactory _formsFactory = null;
        private readonly IPlayerRepository _playerRepository = null;
        private readonly IClubRepository _clubRepository = null;
        private readonly IMatchResultRepository _matchResultRepository = null;

        public MainFormController(IWindowFormsFactory windowFormsFactory, IPlayerRepository playerRepository, IClubRepository clubRepository, IMatchResultRepository matchResultRepository)
        {
            _formsFactory = windowFormsFactory;
            _playerRepository = playerRepository;
            _clubRepository = clubRepository;
            _matchResultRepository = matchResultRepository;
            CreateRandomData();
        }

        public void ShowMatchCreator()
        {
            var matchController = new MatchController(_matchResultRepository, _clubRepository, _playerRepository);
            var createMatchForm = _formsFactory.matchCreatorForm();
            matchController.ShowMatchCreator(createMatchForm, this);
        }

        public void ShowMatch(MatchSquad homeSquad, MatchSquad awaySquad)
        {
            var matchController = new MatchController(_matchResultRepository, _clubRepository, _playerRepository);
            var matchForm = _formsFactory.matcForm();
            matchController.ShowMatch(matchForm, homeSquad, awaySquad);
        }

        public void ShowPlayers()
        {
            var playerController = new PlayerController(_playerRepository);
            var listForm = _formsFactory.playersListForm();
            playerController.ShowPlayers(listForm, this);
        }

        public void AddPlayer()
        {
            var playerController = new PlayerController(_playerRepository);
            var createForm = _formsFactory.cretePlayerForm();
            playerController.ShowAddNewPlayer(createForm);
        }

        public void EditPlayer(string playerId)
        {
            throw new NotImplementedException();
        }

        public void ShowClubs()
        {
            var clubController = new ClubController(_clubRepository);
            var clubListForm = _formsFactory.clubsListForm();
            clubController.ShowClubs(clubListForm, this);
        }

        public void AddClub()
        {
            var clubController = new ClubController(_clubRepository);
            var createClubForm = _formsFactory.creteClubForm();
            clubController.ShowAddNewClub(createClubForm);
        }

        public void EditClub(string playerId)
        {
            throw new NotImplementedException();
        }

        public void CreateRandomData()
        {
            List<Player> squad1 = PlayerFactory.GetRandomSquad();
            List<Player> squad2 = PlayerFactory.GetRandomSquad();
            _playerRepository.addPlayers(squad1);
            _playerRepository.addPlayers(squad2);
            Club homeClub = new Club("Dinamo", "DIN", "Danijel", Tactic.possesion);
            Club awayClub = new Club("Rijeka", "RIJ", "Paulo", Tactic.counterAttack);
            homeClub.SignPlayers(squad1.ConvertAll(x => x.Id));
            awayClub.SignPlayers(squad2.ConvertAll(x => x.Id));
            _playerRepository.playersSignedForClub(squad1.ConvertAll(x => x.Id), homeClub.Id);
            _playerRepository.playersSignedForClub(squad2.ConvertAll(x => x.Id), awayClub.Id);
            _clubRepository.addClub(homeClub);
            _clubRepository.addClub(awayClub);

            // IMatchSimulator matchSimulator = new MyMatchSimulator();
            // matchSimulator.Simulate(homeClub, awayClub, _playerRepository, null, null);
        }


    }
}
