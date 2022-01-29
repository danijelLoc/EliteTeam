using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public struct ClubDescriptor
    {
        public string Id { get; }
        public List<string> ClubSquad { get; }
        public string Name { get; }
        public string ClubManager { get; }
        public Tactic Tactic { get; }
        public string ShortName { get; }

        public ClubDescriptor(string id, List<string> clubSquad, string name, string clubManager, Tactic tactic, string shortName)
        {
            Id = id;
            ClubSquad = clubSquad;
            Name = name;
            ClubManager = clubManager;
            Tactic = tactic;
            ShortName = shortName;
        }
        public ClubDescriptor(Club club)
        {
            Id = club.Id;
            ClubSquad = new List<string>(club.ClubSquad);
            Name = club.Name;
            ClubManager = club.ClubManager;
            Tactic = club.Tactic;
            ShortName = club.ShortName;
        }
    }
}
