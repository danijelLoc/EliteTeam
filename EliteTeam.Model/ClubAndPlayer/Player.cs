using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public class Player : Human
    {
        private PlayerPosition _position;
        public PlayerPosition Position { get { return _position; } }
        public string ClubId { get; set; }
        public Stats Stats { get; set; }
        public IPlayerAI PlayerAI { get; set; }

        public PlayerDescription Description { get { return new PlayerDescription(Id, Name, Age.ToString(), _position.ToString()); } }

        public Player(PlayerPosition position, string name, int age, string country, Stats stats) : base(name, age, country)
        {
            ClubId = null;
            _position = position;
            Stats = stats;
        }
    }
}
