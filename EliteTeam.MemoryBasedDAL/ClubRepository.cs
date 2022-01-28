using System;
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
        }

        public void deleteClub(string inClubID)
        {
            _clubs.RemoveAll(x => x.Id == inClubID);
        }

        public void deleteClubWithName(string name)
        {
            _clubs.RemoveAll(x => x.Name == name);
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
    }
}
