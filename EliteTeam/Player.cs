using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam
{
    public class Player : Human
    {
        private PlayerPosition _position;
        public PlayerPosition Position { get { return _position; } }
        public Club Club { get; set; }
        public Stats Stats { get; set; }
        public PlayerAI PlayerAI { get; set; }

        public Player(PlayerPosition position, string name, int age, Stats stats) : base(name, age)
        {
            _id = Guid.NewGuid().ToString();
            _position = position;
            Stats = stats;
        }
    }
}
