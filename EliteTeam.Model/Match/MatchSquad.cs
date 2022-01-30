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
        public MatchFormation MatchFormation { get; }

        public MatchSquad(IPlayerRepository playerRepository, Club club)
        {
            Club = club;

            // default formation, formation change is not this applications use case
            MatchFormation = new MatchFormation(4, 3, 3);

            var allAttackers = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.attacker, club.Id);
            var allMidfielders = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.midfielder, club.Id);
            var allDefenders = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.defender, club.Id);
            // create match squad for given formation
            if (allAttackers.Count >= MatchFormation.NumOfAttackers
                && allMidfielders.Count >= MatchFormation.NumOfMidfielders
                && allDefenders.Count >= MatchFormation.NumOfDefenders)
            {
                Attack = (List<Player>)allAttackers.GetRange(0, MatchFormation.NumOfAttackers);
                Midfield = (List<Player>)allMidfielders.GetRange(0, MatchFormation.NumOfMidfielders);
                Defence = (List<Player>)allDefenders.GetRange(0, MatchFormation.NumOfDefenders);
            }
            else
            {
                // squad is not valid for this formation
                Attack = null;
                Defence = null;
                Midfield = null;
            }
            var goalKeepers = playerRepository.getAllPlayersInPositionAtClub(PlayerPosition.goalkeeper, club.Id);
            GoalKeeper = goalKeepers.Count > 0 ? goalKeepers[0] : null;
        }

        public bool IsSquadValid()
        {
            if (Attack == null || Midfield == null || Defence == null || GoalKeeper == null) return false;
            return (Attack.Count + Midfield.Count + Defence.Count + 1) == 11;
        }
    }
}