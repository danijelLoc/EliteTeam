using System;

namespace EliteTeam.Model
{
    public class MatchResult
    {
        public string Id { get; }
        public string HomeClubName { get; }
        private string AwayClubName { get; }
        public int HomeClubGoals { get; }
        public int AwayClubGoals { get; }
        public DateTime KickOffDate { get; }

        public MatchResult(string homeClubName, string awayClubName, int homeClubGoals, int awayClubGoals, DateTime date)
        {
            Id = Guid.NewGuid().ToString();
            HomeClubName = homeClubName;
            AwayClubName = awayClubName;
            HomeClubGoals = homeClubGoals;
            AwayClubGoals = awayClubGoals;
            KickOffDate = date;
        }
    }
}
