using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public interface IPlayerRepository : ISubject
    {
        int getNumberOfPlayers();
        Player getPlayerByID(string playerId);
        List<Player> getPlayersWithName(string name);
        string getPlayersClubId(string playerId);
        List<Player> getAllPlayers();
        List<string> getAllPlayersIDs();
        List<Player> getAllPlayersInPosition(PlayerPosition position);
        List<Player> getAllPlayersInClub(string clubId);
        List<Player> getAllFreeAgentPlayers();
        List<Player> getAllPlayersInPositionAtClub(PlayerPosition position, string clubId);
        void addPlayer(Player inPlayer);
        void addPlayers(List<Player> inPlayers);
        void deletePlayer(string inPlyerID);
        void updatePlayerStatsAndName(string plyerID, Stats stats, string name);
        void playerSignedForClub(string playerId, string clubId);
        void playerFiredFromClub(string playerId, string clubId);
        void playersSignedForClub(List<string> playerIds, string clubId);
        bool doesPlayerExists(string name);

    }
}
