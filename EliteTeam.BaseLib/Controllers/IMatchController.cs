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
        void ShowMatch(string homwClubId, string awayClubId);
        public List<Club> GetClubs();
        public List<MatchResult> GetMatchResults();
        public void TryToAddMatchResult(IMatchView matchView);
        public void TryToCreateMatch(ICreateMatchView matchCreatorView);
    }
}
