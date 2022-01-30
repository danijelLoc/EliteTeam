using System;

namespace EliteTeam.Model
{
    public class Player : Human
    {
        private Stats _stats;
        private PlayerPosition _position;
        public PlayerPosition Position { get { return _position; } }
        public string ClubId { get; set; }
        public IPlayerAI PlayerAI { get; set; }
        public Stats Stats
        {
            get { return _stats; }
            set
            {
                if (value == null) throw new ArgumentNullException("Stats cannot be null");
                _stats = value;
            }
        }


        public Player(PlayerPosition position, string name, int age, string country, Stats stats, IPlayerAI playerAI = null) : base(name, age, country)
        {
            if (Age < 17 || Age >= 43) throw new PlayerAgeException();
            ClubId = null;
            _position = position;
            Stats = stats;
            PlayerAI = playerAI;
        }
        public Player(PlayerPosition position, string name, DateTime birthday, string country, Stats stats, IPlayerAI playerAI = null) : base(name, birthday, country)
        {
            if (Age < 17 || Age >= 43) throw new PlayerAgeException();
            ClubId = null;
            _position = position;
            Stats = stats;
            PlayerAI = playerAI;
        }
    }
}
