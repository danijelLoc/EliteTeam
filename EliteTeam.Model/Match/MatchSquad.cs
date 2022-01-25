using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public struct MatchSquad
    {
        // CLUB instead of id
        public string ClubId { get; }
        public List<Player> Attack { get; }
        public List<Player> Midfield { get; }
        public List<Player> Defence { get; }
        public Player GoalKeeper { get; }

        public MatchSquad(IPlayerRepository playerRepository, string clubId)
        {
            ClubId = clubId;
            Attack = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.attacker, clubId);
            Midfield = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.midfielder, clubId);
            Defence = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.defender, clubId);
            var goalKeepers = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.goalkeeper, clubId);
            GoalKeeper = goalKeepers.Count > 0 ? goalKeepers[0] : null;
        }

        public bool IsSquadValid()
        {
            return (GoalKeeper != null && (Attack.Count + Midfield.Count + Defence.Count + 1) >= 11);
        }
    }
}