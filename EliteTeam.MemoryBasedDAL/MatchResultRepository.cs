using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.MemoryBasedDAL
{
    public class MatchResultRepository : IMatchResultRepository
    {
        private List<MatchResult> _results;
        private static MatchResultRepository _instance;
        public static MatchResultRepository Shared
        {
            get
            {
                return _instance ?? (_instance = new MatchResultRepository());
            }
        }

        private MatchResultRepository()
        {
            _results = new List<MatchResult>();
        }

        public void addMatchResult(MatchResult inMatchResult)
        {
            if (_results.Find(x => x.Id == inMatchResult.Id) != null)
                throw new MatchResultTakenIdException();
            _results.Add(inMatchResult);
        }

        public List<MatchResult> getAllMatchResults()
        {

            return new List<MatchResult>(_results);
        }

        public List<MatchResult> getAllMatchResultsWithClub(string clubId)
        {
            return _results.FindAll(x => x.HomeClubId == clubId || x.AwayClubId == clubId);
        }

        public MatchResult getMatchResultByID(string MatchResultId)
        {
            return _results.Find(x => x.Id == MatchResultId);
        }

        public int getNumberOfMatchResults()
        {
            return _results.Count;
        }

        public void deleteAll()
        {
            _results.Clear();
        }
    }
}
