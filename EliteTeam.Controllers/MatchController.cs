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

        public MatchController(IMatchResultRepository matchResultRepository, IClubRepository clubRepository)
        {
            _matchResultRepository = matchResultRepository;
            _clubRepository = clubRepository;
        }

        public List<Club> GetClubs()
        {
            return _clubRepository.getAllClubs();
        }

        public List<MatchResult> GetMatchResults()
        {
            return _matchResultRepository.getAllMatchResults();
        }

        public void ShowMatch(string homwClubId, string awayClubId)
        {
            throw new NotImplementedException();
        }


        public void ShowMatchCreator(ICreateMatchView createMatchView, IMainFormController mainFormController)
        {
            createMatchView.ShowModaless(this);
        }

        public void TryToAddMatchResult(IMatchView matchView)
        {
            throw new NotImplementedException();
        }

        public void TryToCreateMatch(ICreateMatchView matchCreatorView)
        {
            throw new NotImplementedException();
        }
    }
}
