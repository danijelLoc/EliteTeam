using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public interface IPlayerRepository
    {
        int getNumberOfPlayers();
        Player getPlayerByID(string playerId);
        List<Player> getPlayersWithName(string name);
        string getPlayersClubId(string playerId);
        List<Player> getAllPlayers(string name);
        List<PlayerDescription> getAllPlayersDescriptions();
        List<string> getAllPlayersIDs();
        List<Player> getAllPlayersInPosition(PlayerPosition position);
        List<Player> getAllPlayersInClub(string clubId);
        List<Player> getAllPlayersInPositionAtClub(PlayerPosition position, string clubId);

        string getNewID();
        bool doesPlayerExists(string name);

        void addPlayer(Player inPlayer);
        void deletePlayer(string inPlyerID);
    }
}
