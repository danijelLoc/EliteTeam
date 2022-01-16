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
        List<Player> getAllPlayers();
        List<PlayerDescription> getAllPlayersDescriptions();
        List<string> getAllPlayersIDs();
        List<Player> getAllPlayersInPosition(PlayerPosition position);
        List<Player> getAllPlayersInClub(string clubId);
        List<Player> getAllFreeAgentPlayers();
        List<Player> getAllPlayersInPositionAtClub(PlayerPosition position, string clubId);
        void playerSignedForClub(string playerId, string clubId);
        void playersSignedForClub(List<string> playerIds, string clubId);
        bool doesPlayerExists(string name);
        void addPlayer(Player inPlayer);
        void addPlayers(List<Player> inPlayers);
        void deletePlayer(string inPlyerID);
    }
}
