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
            IMatchSimulationController simulator = new MatchSimulationController(this);
            matchView.ShowModaless(simulator, this, homeSquad, awaySquad);
            simulator.CreateSimulation(matchView, homeSquad, awaySquad);
        }


        public void ShowMatchCreator(ICreateMatchView createMatchView, IMainController mainController)
        {
            if (_clubRepository.getAllClubs().Count < 2) throw new NotEnoughClubsForMatchCreator();
            createMatchView.ShowModaless(this, mainController);

        }
        public void CreateMatch(ICreateMatchView matchCreatorView, IMainController mainViewController)
        {
            if (matchCreatorView.AwayClubName == matchCreatorView.HomeClubName)
                throw new MatchSameClubsException();
            var homeClub = _clubRepository.getClubWithName(matchCreatorView.HomeClubName);
            var awayClub = _clubRepository.getClubWithName(matchCreatorView.AwayClubName);
            MatchSquad homeMatchSquad = new MatchSquad(_playerRepository, homeClub);
            MatchSquad awayMatchSquad = new MatchSquad(_playerRepository, awayClub);
            if (!homeMatchSquad.IsSquadValid())
                throw new MatchInvalidHomeSquad();
            if (!awayMatchSquad.IsSquadValid())
                throw new MatchInvalidAwaySquad();
            matchCreatorView.CloseView();
            mainViewController.ShowMatch(homeMatchSquad, awayMatchSquad);
        }

        public void AddMatchResult(IMatchView matchView, MatchResult matchResult)
        {
            _matchResultRepository.addMatchResult(matchResult);
            matchView.ShowMessage("Match Result Saved");

        }

        public void ShowMatchResults(IMatchResultsListView inView, IMainController mainController)
        {
            inView.ShowModaless(this, mainController);
        }
    }
}
