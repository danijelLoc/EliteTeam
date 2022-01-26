using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public struct MatchSquad
    {
        // CLUB instead of id
        public Club Club { get; }
        public List<Player> Attack { get; }
        public List<Player> Midfield { get; }
        public List<Player> Defence { get; }
        public Player GoalKeeper { get; }

        public MatchSquad(IPlayerRepository playerRepository, Club club)
        {
            Club = club;
            Attack = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.attacker, club.Id);
            Midfield = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.midfielder, club.Id);
            Defence = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.defender, club.Id);
            var goalKeepers = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.goalkeeper, club.Id);
            GoalKeeper = goalKeepers.Count > 0 ? goalKeepers[0] : null;
        }

        public bool IsSquadValid()
        {
            return (GoalKeeper != null && (Attack.Count + Midfield.Count + Defence.Count + 1) >= 11);
        }
    }
}