using System;

namespace EliteTeam.Model
{
    public class MatchResult
    {
        public string Id { get; }
        public string HomeClubId { get; }
        private string AwayClubId { get; }
        public int HomeClubGoals { get; }
        public int AwayClubGoals { get; }
        public DateTime KickOffDate { get; }

        public MatchResult(string homeClubId, string awayClubId, int homeClubGoals, int awayClubGoals, DateTime date)
        {
            Id = Guid.NewGuid().ToString();
            HomeClubId = homeClubId;
            AwayClubId = awayClubId;
            HomeClubGoals = homeClubGoals;
            AwayClubGoals = awayClubGoals;
            KickOffDate = date;
        }
    }
}
