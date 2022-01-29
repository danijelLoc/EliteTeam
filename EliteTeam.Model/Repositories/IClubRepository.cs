using System.Collections.Generic;

namespace EliteTeam.Model
{
    public interface IClubRepository : ISubject
    {
        int getNumberOfClubs();
        Club getClubByID(string ClubId);
        List<string> getClubPlayersIds(string ClubId);
        List<Club> getAllClubs();
        Club getClubWithName(string name);
        List<string> getAllClubsIDs();
        bool doesClubExists(string name);
        void addClub(Club inClub);
        void updateClub(string clubId, ClubDescriptor updatedInfo);
        void deleteClub(string inClubID);
        void deleteClubWithName(string name);
        void clubSignedPlayer(string playerId, string clubId);
        void clubFiredPlayer(string playerId, string clubId);
        void clubFiredAllPlayers(string clubId);
    }
}