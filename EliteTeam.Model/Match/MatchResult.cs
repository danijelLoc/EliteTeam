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
        public DateTime KickOffTime { get; }

        public MatchResult(Club homeClub, Club awayClub, int homeClubGoals, int awayClubGoals, DateTime kickOffTime)
        {
            Id = Guid.NewGuid().ToString();
            HomeClubName = homeClub.Name;
            HomeClubId = homeClub.Id;
            AwayClubName = awayClub.Name;
            AwayClubId = awayClub.Id;
            HomeClubGoals = homeClubGoals;
            AwayClubGoals = awayClubGoals;
            KickOffTime = kickOffTime;
        }
    }
}
