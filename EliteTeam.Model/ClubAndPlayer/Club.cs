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
        private string _name;
        private string _shortName;
        private string _clubManagerName;
        public List<string> ClubSquad { get { return _squad; } }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Trim().Length < 3)
                    throw new ClubInvalidNameException();
                _name = value.Trim();
            }
        }
        public string ClubManager
        {
            get { return _clubManagerName; }
            set
            {
                if (value.Length < 2)
                    throw new HumanNameLengthException();
                _clubManagerName = value;
            }
        }
        public Tactic Tactic { get; set; }
        public string ShortName
        {
            get { return _shortName; }
            set
            {
                if (value.Trim().Length != 3)
                    throw new ClubInvalidShortNameException();
                _shortName = value.Trim().ToUpper();
            }
        }

        public Club(string name, string shortName, String clubManager, Tactic tactic) : base(Guid.NewGuid().ToString())
        {
            Name = name;
            ShortName = shortName;
            _squad = new List<string>(); // squad is filled additionaly
            ClubManager = clubManager;
            Tactic = tactic;
        }

        public void SignPlayer(string playerId)
        {
            _squad.Add(playerId);
        }

        public void SignPlayers(List<string> playerIds)
        {
            foreach (string playerId in playerIds)
                SignPlayer(playerId);
        }

        public void FirePlayer(string playerId)
        {
            var removed = _squad.Remove(playerId);
            if (!removed) throw new ClubPlayerMissingException();
        }
        public void FireAllPlayers()
        {
            _squad.Clear();
        }
    }
}