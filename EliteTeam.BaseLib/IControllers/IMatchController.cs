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
        public void ShowMatchCreator(ICreateMatchView createMatchView, IMainFormController mainFormController);
        void ShowMatch(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad);
        public List<Club> GetClubs();
        public List<MatchResult> GetMatchResults();
        public void TryToCreateMatch(ICreateMatchView matchCreatorView, IMainFormController mainFormController);
        public void TryToAddMatchResult(IMatchView matchView);

    }
}
