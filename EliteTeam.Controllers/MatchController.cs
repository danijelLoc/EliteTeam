using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.BaseLib;
using EliteTeam.Model;

namespace EliteTeam.Controllers
{
    public class MatchController : IMatchController
    {
        private IMatchResultRepository _matchResultRepository;
        private IClubRepository _clubRepository;
        private IPlayerRepository _playerRepository;
        private IMatchSimulationController _matchSimulationController;

        public MatchController(IMatchResultRepository matchResultRepository, IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            _matchResultRepository = matchResultRepository;
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }

        public List<Club> GetClubs()
        {
            return _clubRepository.getAllClubs();
        }

        public List<MatchResult> GetMatchResults()
        {
            return _matchResultRepository.getAllMatchResults();
        }

        public void ShowMatch(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad)
        {
            matchView.ShowModaless(this, homeSquad, awaySquad);
            var simulator = new MatchSimulationController(_matchResultRepository);
            simulator.CreateSimulation(matchView, homeSquad, awaySquad);
            matchView.StartSimulation(simulator);
        }


        public void ShowMatchCreator(ICreateMatchView createMatchView, IMainFormController mainFormController)
        {
            createMatchView.ShowModaless(this, mainFormController);

        }
        public void TryToCreateMatch(ICreateMatchView matchCreatorView, IMainFormController mainFormController)
        {
            if (matchCreatorView.AwayClubName == matchCreatorView.HomeClubName)
                throw new ArgumentException("Selected same club twice, please select different clubs.");
            var homeClub = _clubRepository.getClubWithName(matchCreatorView.HomeClubName);
            var awayClub = _clubRepository.getClubWithName(matchCreatorView.AwayClubName);
            MatchSquad homeMatchSquad = new MatchSquad(_playerRepository, homeClub);
            MatchSquad awayMatchSquad = new MatchSquad(_playerRepository, awayClub);
            if (!homeMatchSquad.IsSquadValid())
                throw new ArgumentException("Home match  squad is not valid, lack of players or goalkeeper.");
            if (!awayMatchSquad.IsSquadValid())
                throw new ArgumentException("Away match  squad is not valid, lack of players or goalkeeper.");
            matchCreatorView.CloseView();
            mainFormController.ShowMatch(homeMatchSquad, awayMatchSquad);
        }

        public void TryToAddMatchResult(IMatchView matchView)
        {
            throw new NotImplementedException();
        }


    }
}
