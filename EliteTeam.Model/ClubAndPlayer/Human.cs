using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Human : EntityBase<string>
    {
        public string Name { get; set; }
        public string Country { get; }
        private DateTime _birthDay;
        public int Age { get { return DateTime.Now.Year - _birthDay.Year; } }

        public Human(string name, int age, string country) : base(Guid.NewGuid().ToString())
        {
            Name = name;
            Country = country;
            _birthDay = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);
        }

        public Human(string name, DateTime birthday, string country) : base(Guid.NewGuid().ToString())
        {
            Name = name;
            Country = country;
            _birthDay = birthday;
        }
    }
}