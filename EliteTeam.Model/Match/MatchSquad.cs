using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public struct MatchSquad
    {
        public String ClubId { get; }
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
            GoalKeeper = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.goalkeeper, clubId)[0];
        }

        public bool IsSquadValid()
        {
            return (GoalKeeper != null && (Attack.Count + Midfield.Count + Defence.Count + 1) >= 11);
        }
    }
}