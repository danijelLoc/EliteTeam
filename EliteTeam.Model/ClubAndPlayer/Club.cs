using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Club
    {
        // TODO no same name clubs, ENTITY !!!!!!!!!!!!! ZA HUMAN I CLUB
        public static readonly int MinNumberOfPlayers = 11;

        private List<string> _squad;
        public string Id { get; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<string> ClubSquad { get { return _squad; } }
        public string ClubManager { get; set; }
        public Tactic Tactic { get; set; }

        public Club(string name, string shortName, String clubManager, Tactic tactic)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            ShortName = shortName;
            _squad = null;
            ClubManager = clubManager;
        }

        public void SignPlayer(string playerId)
        {
            if (ClubSquad == null) _squad = new List<string>();
            _squad.Append(playerId);
        }
        public void SignPlayers(List<string> playerIds)
        {
            if (ClubSquad == null) _squad = new List<string>();
            foreach (string playerId in playerIds)
                SignPlayer(playerId);
        }
    }
}