﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.MemoryBasedDAL
{
    public class ClubRepository : IClubRepository
    {
        private List<Club> _clubs = null;
        public static ClubRepository Shared = new ClubRepository();

        private ClubRepository()
        {
            _clubs = new List<Club>();
        }

        public void addClub(Club inClub)
        {
            if (_clubs.Find(x => x.Id == inClub.Id) != null)
                return;
            _clubs.Add(inClub);
        }

        public void deleteClub(string inClubID)
        {
            _clubs.RemoveAll(x => x.Id == inClubID);
        }

        public bool doesClubExists(string name)
        {
            return _clubs.Find(x => x.Name == name) != null;
        }

        public List<Club> getAllClubs()
        {
            return new List<Club>(_clubs);
        }

        public List<string> getAllClubsIDs()
        {
            return _clubs.ConvertAll(x => x.Id);
        }

        public Club getClubByID(string ClubId)
        {
            return _clubs.Find(x => x.Id == ClubId);
        }

        public List<string> getClubPlayersIds(string ClubId)
        {
            var club = _clubs.Find(x => x.Id == ClubId);
            if (club == null) return null;
            return club.ClubSquad;
        }

        public List<Club> getClubsWithName(string name)
        {
            return _clubs.FindAll(x => x.Name == name);
        }

        public int getNumberOfClubs()
        {
            return _clubs.Count;
        }
    }
}