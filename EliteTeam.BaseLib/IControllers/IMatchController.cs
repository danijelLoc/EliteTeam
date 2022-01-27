using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IMatchController
    {
        public void ShowMatchCreator(ICreateMatchView createMatchView, IMainController mainController);
        void ShowMatch(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad);
        public List<Club> GetClubs();
        public List<MatchResult> GetMatchResults();
        public void TryToCreateMatch(ICreateMatchView matchCreatorView, IMainController mainController);
        public void TryToAddMatchResult(IMatchView matchView, MatchResult matchResult);
        public void ShowMatchResults(IMatchResultsListView inView, IMainController mainController);

    }
}
