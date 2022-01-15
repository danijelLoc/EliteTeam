using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam
{
    public class Human
    {
        protected string _id;
        public string Id { get { return _id; } }

        public string Name { get; set; }

        public int Age { get; set; }

        public Human(string name, int age)
        {
            _id = Guid.NewGuid().ToString();
            Name = name;
            Age = age;
        }
    }
}