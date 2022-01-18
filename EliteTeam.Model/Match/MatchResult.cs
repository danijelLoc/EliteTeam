using System;

namespace EliteTeam.Model
{
    public class MatchResult
    {
        public string Id { get; }
        public string HomeClubName { get; }
        public string HomeClubId { get; }
        public string AwayClubName { get; }
        public string AwayClubId { get; }
        public int HomeClubGoals { get; }
        public int AwayClubGoals { get; }
        public DateTime KickOffDate { get; }

        public MatchResult(string homeClubName, string homwClubId, string awayClubName, string awayClubId, int homeClubGoals, int awayClubGoals, DateTime date)
        {
            Id = Guid.NewGuid().ToString();
            HomeClubName = homeClubName;
            HomeClubId = HomeClubId;
            AwayClubName = awayClubName;
            AwayClubId = awayClubId;
            HomeClubGoals = homeClubGoals;
            AwayClubGoals = awayClubGoals;
            KickOffDate = date;
        }
    }
}
