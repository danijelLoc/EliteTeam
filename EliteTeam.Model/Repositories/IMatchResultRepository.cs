using System.Collections.Generic;

namespace EliteTeam.Model
{
    public interface IMatchResultRepository
    {
        int getNumberOfMatchResults();
        MatchResult getMatchResultByID(string MatchResultId);
        List<MatchResult> getAllMatchResults();
        List<MatchResult> getAllMatchResultsWithClub(string clubId);
        void addMatchResult(MatchResult inMatchResult);
    }
}