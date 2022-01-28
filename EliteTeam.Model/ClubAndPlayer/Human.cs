using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Human : EntityBase<string>
    {
        private string _countryName;
        private DateTime _birthDay;
        public string Name { get; set; }
        public string Country { get { return _countryName; } }
        public int Age { get { return DateTime.Now.Year - _birthDay.Year; } }

        public Human(string name, int age, string country) : base(Guid.NewGuid().ToString())
        {
            SetNames(name, country);
            if (age < 0) throw new NegativeAgeException();
            _birthDay = new DateTime(DateTime.Now.Year - age, DateTime.Now.Month, DateTime.Now.Day);
        }

        public Human(string name, DateTime birthday, string country) : base(Guid.NewGuid().ToString())
        {
            if (birthday > DateTime.Now) throw new NegativeAgeException();
            SetNames(name, country);
            _birthDay = birthday;
        }

        private void SetNames(string name, string country)
        {
            if (name.Trim().Length < 2) throw new HumanNameLengthException();
            if (country.Trim().Length < 2) throw new CountryNameLengthException();
            Name = name.Trim();
            _countryName = country.Trim();
        }
    }
}