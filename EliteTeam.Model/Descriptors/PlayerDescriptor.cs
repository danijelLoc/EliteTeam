using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public struct PlayerDescriptor
    {
        public string Id { get; }
        public string Name { get; }
        public string Country { get; }
        public int Age { get; }
        public PlayerPosition Position { get; }
        public string ClubId { get; }
        public Stats Stats { get; }

        public PlayerDescriptor(string id, string name, string country, int age, PlayerPosition position, string clubId, Stats stats)
        {
            Id = id;
            Name = name;
            Country = country;
            Age = age;
            Position = position;
            ClubId = clubId;
            Stats = stats;
        }

        public PlayerDescriptor(Player player)
        {
            Id = player.Id;
            Name = player.Name;
            Country = player.Country;
            Age = player.Age;
            Position = player.Position;
            ClubId = player.ClubId;
            Stats = player.Stats;
        }
    }
}
