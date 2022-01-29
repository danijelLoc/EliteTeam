using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;
using System.Collections.ObjectModel;

namespace EliteTeam.MemoryBasedDAL
{
    public class ClubRepository : Subject, IClubRepository
    {
        private List<Club> _clubs = null;
        private static ClubRepository _instance;

        public static ClubRepository Shared
        {
            get
            {
                return _instance ?? (_instance = new ClubRepository());
            }
        }

        private ClubRepository()
        {
            _clubs = new List<Club>();
        }

        public void addClub(Club inClub)
        {
            if (_clubs.Find(x => x.Id == inClub.Id) != null)
                throw new ClubTakenIdException();
            if (_clubs.Find(x => x.Name == inClub.Name) != null)
                throw new ClubTakenNameException();
            if (_clubs.Find(x => x.ShortName == inClub.ShortName) != null)
                throw new ClubTakenShortNameException();
            _clubs.Add(inClub);

            NotifyObservers();
        }

        public void deleteClub(string inClubID)
        {
            _clubs.RemoveAll(x => x.Id == inClubID);
            NotifyObservers();
        }

        public void deleteClubWithName(string name)
        {
            _clubs.RemoveAll(x => x.Name == name);
            NotifyObservers();
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

        public Club getClubWithName(string name)
        {
            return _clubs.Find(x => x.Name == name);
        }

        public int getNumberOfClubs()
        {
            return _clubs.Count;
        }

        public void clubSignedPlayer(string playerId, string clubId)
        {
            var club = _clubs.Find(x => x.Id == clubId);
            club.SignPlayer(playerId);
        }

        public void clubFiredPlayer(string playerId, string clubId)
        {
            var club = _clubs.Find(x => x.Id == clubId);
            club.FirePlayer(playerId);
        }
        public void clubFiredAllPlayers(string clubId)
        {
            var club = _clubs.Find(x => x.Id == clubId);
            club.FireAllPlayers();
        }

        public void updateClub(string clubId, ClubDescriptor updatedInfo)
        {
            // UPDATES BASIC INFO, SQUAD IS UPDATED THROUGH TRANSFERS(clubFiredPlayer, clubSignedPlayer) 
            // AND NOT DIRECTLY !!
            Club club = getClubByID(clubId);
            if (club == null) throw new ClubIdMissingException();
            List<Club> otherClubs = _clubs.FindAll(x => x.Id != clubId);

            if (otherClubs.FindAll(x => x.Name == updatedInfo.Name).Count != 0)
                throw new ClubTakenNameException();
            if (otherClubs.FindAll(x => x.ShortName == updatedInfo.ShortName).Count != 0)
                throw new ClubTakenShortNameException();
            if (otherClubs.FindAll(x => x.ClubManager == updatedInfo.ClubManager).Count != 0)
                throw new ClubTakenManagerException();

            club.Name = updatedInfo.Name;
            club.ShortName = updatedInfo.ShortName;
            club.ClubManager = updatedInfo.ClubManager;
            club.Tactic = updatedInfo.Tactic;

            NotifyObservers();
        }
    }
}
