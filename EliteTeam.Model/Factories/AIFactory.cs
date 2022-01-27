using System;

namespace EliteTeam.Model
{
    public class AIFactory
    {
        public static IPlayerAI CreateAI(PlayerPosition playerPosition)
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
