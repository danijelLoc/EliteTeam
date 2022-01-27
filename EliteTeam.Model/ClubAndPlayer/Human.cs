using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Human
    {
        public string Id { get; }
        public string Name { get; set; }
        public string Country { get; }
        public int Age { get; set; }

        public Human(string name, int age, string country)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Country = country;
            Age = age;
        }
    }
}