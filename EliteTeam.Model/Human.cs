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

        public int Age { get; set; }

        public Human(string name, int age)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Age = age;
        }
    }
}