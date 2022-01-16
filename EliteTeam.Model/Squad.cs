using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Squad
    {
        // Subtitutions disabled for simplicity sake
        public readonly static int MinNumberOfPlayers = 11;
        private List<Player> _players;
        public List<Player> Attack => _players.FindAll(p => p.Position == PlayerPosition.attacker);
        public List<Player> Midfield => _players.FindAll(p => p.Position == PlayerPosition.midfielder);
        public List<Player> Defence => _players.FindAll(p => p.Position == PlayerPosition.defender);
        public Player GoalKeeper => _players.Find(p => p.Position == PlayerPosition.goalkeeper);

        public Squad(List<Player> players)
        {
            _players = players;
        }

        public bool IsSquadValid()
        {
            return (GoalKeeper != null && (Attack.Count + Midfield.Count + Defence.Count + 1) >= MinNumberOfPlayers);
        }
    }
}