using System.Collections.Generic;

namespace EliteTeam.Model
{
    public interface IClubRepository
    {
        int getNumberOfClubs();
        Club getClubByID(string ClubId);
        List<string> getClubPlayersIds(string ClubId);
        List<Club> getAllClubs();
        List<Club> getClubsWithName(string name);
        List<string> getAllClubsIDs();
        bool doesClubExists(string name);
        void addClub(Club inClub);
        void deleteClub(string inClubID);
    }
}