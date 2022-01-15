using System;

namespace EliteTeam.AI
{
    class AIFactory
    {
        public static PlayerAI CreateAI(PlayerPosition playerPosition)
        {
            switch (playerPosition)
            {
                case PlayerPosition.attacker:
                    return new AttackerAI();
                case PlayerPosition.midfielder:
                    return new MidfielderAI();
                case PlayerPosition.defender:
                    return new DefenderAI();
                case PlayerPosition.goalkeeper:
                    return new DefenderAI();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
