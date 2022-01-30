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

        public Player(PlayerPosition position, string name, int age, string country, Stats stats, IPlayerAI playerAI = null) : base(name, age, country)
        {
            if (age <= 16 || age >= 43) throw new PlayerAgeException();
            ClubId = null;
            _position = position;
            Stats = stats;
            PlayerAI = playerAI;
        }
        public Player(PlayerPosition position, string name, DateTime birthday, string country, Stats stats, IPlayerAI playerAI = null) : base(name, birthday, country)
        {
            if (Age < 17) throw new PlayerAgeException();
            ClubId = null;
            _position = position;
            Stats = stats;
            PlayerAI = playerAI;
        }
    }
}
