using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Club : EntityBase<string>
    {
        public static readonly int MinNumberOfPlayers = 11;

        private List<string> _squad;
        private string _shortName;
        public string Name { get; set; }
        public List<string> ClubSquad { get { return _squad; } }
        public string ClubManager { get; set; }
        public Tactic Tactic { get; set; }
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                if (value.Length != 3)
                    throw new ArgumentException("Short name must be 3 characters long");
                _shortName = value.ToUpper();
            }
        }

        public Club(string name, string shortName, String clubManager, Tactic tactic) : base(Guid.NewGuid().ToString())
        {
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

        public void FirePlayer(string playerId)
        {
            var removed = _squad.Remove(playerId);
            if (!removed) throw new Exception("Player was not in squad");
        }
        public void FireAllPlayers()
        {
            _squad.Clear();
        }
    }
}