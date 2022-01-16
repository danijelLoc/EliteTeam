using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Club
    {
        public string Id { get; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public Squad ClubSquad { get; }
        public Manager ClubManager { get; set; }
        public Tactic Tactic { get; set; }

        public Club(string name, string shortName, Squad clubSquad, Manager clubManager, Tactic tactic)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            ShortName = shortName;
            ClubSquad = clubSquad;
            SignPlayers();
            ClubManager = clubManager;
        }

        private void SignPlayers()
        {
            foreach (Player player in ClubSquad.Attack)
                player.Club = this;
            foreach (Player player in ClubSquad.Midfield)
                player.Club = this;
            foreach (Player player in ClubSquad.Defence)
                player.Club = this;
            ClubSquad.GoalKeeper.Club = this;
        }
    }
}