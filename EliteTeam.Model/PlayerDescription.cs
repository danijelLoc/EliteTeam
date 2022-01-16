using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public struct PlayerDescription
    {
        string Id;
        string Name;
        string Age;
        string Position;

        public PlayerDescription(string id, string name, string age, string position)
        {
            Id = id;
            Name = name;
            Age = age;
            Position = position;
        }
    }
}
