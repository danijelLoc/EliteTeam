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
        public PlayerAI PlayerAI { get; set; }

        public PlayerDescription Description { get { return new PlayerDescription(_id, Name, Age.ToString(), _position.ToString()); } }

        public Player(PlayerPosition position, string name, int age, Stats stats) : base(name, age)
        {
            _position = position;
            Stats = stats;
        }
    }
}
