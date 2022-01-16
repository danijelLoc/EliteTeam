using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class PlayerFactory
    {
        // TODO REMOVE DETEMINISTIC SEED !!!!!!!!!!!!!!!!!
        static Random r = new Random(10);
        public static Player GetRandomPlayer(PlayerPosition position)
        {
            string randomName = RandomName(r.Next(3, 8));
            int randomAge = r.Next(17, 32);
            Stats randomStats = RandomStats(position);
            Player player = new Player(position, randomName, randomAge, randomStats);
            // adding AI to player, AI is not needed before match, it can be changed with better one in next versions
            player.PlayerAI = AIFactory.CreateAI(position);
            return player;
        }

        public static Stats RandomStats(PlayerPosition position)
        {
            Stats stats = new Stats();
            switch (position)
            {
                case PlayerPosition.attacker:
                    stats.Shooting = r.Next(3, 6);
                    stats.Passing = r.Next(2, 5);
                    stats.Dribling = r.Next(1, 6);
                    stats.Speed = r.Next(2, 6);
                    stats.Stamina = r.Next(1, 6);
                    stats.Strenght = r.Next(1, 6);
                    stats.Interceptions = r.Next(1, 3);
                    stats.Goalkeeping = r.Next(1, 2);
                    break;
                case PlayerPosition.midfielder:
                    stats.Shooting = r.Next(1, 4);
                    stats.Passing = r.Next(4, 6);
                    stats.Dribling = r.Next(3, 6);
                    stats.Speed = r.Next(1, 5);
                    stats.Stamina = r.Next(1, 6);
                    stats.Strenght = r.Next(1, 6);
                    stats.Interceptions = r.Next(2, 6);
                    stats.Goalkeeping = r.Next(1, 2);
                    break;
                case PlayerPosition.defender:
                    stats.Shooting = r.Next(1, 3);
                    stats.Passing = r.Next(2, 5);
                    stats.Dribling = r.Next(1, 3);
                    stats.Speed = r.Next(1, 5);
                    stats.Stamina = r.Next(1, 6);
                    stats.Strenght = r.Next(3, 6);
                    stats.Interceptions = r.Next(3, 6);
                    stats.Goalkeeping = r.Next(1, 2);
                    break;
                case PlayerPosition.goalkeeper:
                    stats.Shooting = r.Next(1, 3);
                    stats.Passing = r.Next(2, 6);
                    stats.Dribling = r.Next(1, 2);
                    stats.Speed = r.Next(1, 2);
                    stats.Stamina = r.Next(1, 2);
                    stats.Strenght = r.Next(1, 6);
                    stats.Interceptions = r.Next(1, 2);
                    stats.Goalkeeping = r.Next(3, 6);
                    break;
            }
            return stats;
        }

        public static List<Player> GetRandomSquad()
        {
            Player p1 = GetRandomPlayer(PlayerPosition.goalkeeper);

            Player p2 = GetRandomPlayer(PlayerPosition.defender);
            Player p3 = GetRandomPlayer(PlayerPosition.defender);
            Player p4 = GetRandomPlayer(PlayerPosition.defender);
            Player p5 = GetRandomPlayer(PlayerPosition.defender);

            Player p6 = GetRandomPlayer(PlayerPosition.midfielder);
            Player p7 = GetRandomPlayer(PlayerPosition.midfielder);
            Player p8 = GetRandomPlayer(PlayerPosition.midfielder);

            Player p9 = GetRandomPlayer(PlayerPosition.attacker);
            Player p10 = GetRandomPlayer(PlayerPosition.attacker);
            Player p11 = GetRandomPlayer(PlayerPosition.attacker);

            return new List<Player>() { p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 };
        }

        public static string RandomName(int len)
        {
            string[] suglasnici = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "t", "v", "z", "w", "x" };
            string[] samoglasnici = { "a", "e", "i", "o", "u" };
            string Name = "";
            Name += suglasnici[r.Next(suglasnici.Length)].ToUpper();
            Name += samoglasnici[r.Next(samoglasnici.Length)];
            int b = 2; //b tells how many times a new letter has been added. It's 2 right now because the first two letters are already in the name.
            while (b < len)
            {
                Name += suglasnici[r.Next(suglasnici.Length)];
                b++;
                Name += samoglasnici[r.Next(samoglasnici.Length)];
                b++;
            }

            return Name;
        }
    }
}