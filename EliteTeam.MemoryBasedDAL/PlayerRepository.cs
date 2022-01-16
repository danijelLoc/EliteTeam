using System;
using System.Collections.Generic;
using EliteTeam.Model;

namespace EliteTeam.MemoryBasedDAL
{
    public class PlayerRepository : IPlayerRepository
    {
        public static PlayerRepository Shared = new PlayerRepository();

        private readonly List<Player> _players = new List<Player>();

        private PlayerRepository()
        {
        }

        public void addPlayer(Player inPlayer)
        {
            if (_players.Find(x => x.Id == inPlayer.Id) == null)
                return;
            _players.Add(inPlayer);
        }

        public void deletePlayer(string inPlyerID)
        {
            _players.RemoveAll(x => x.Id == inPlyerID);
        }

        public bool doesPlayerExists(string name)
        {
            return _players.Find(x => x.Name == name) != null;
        }

        public int getNumberOfPlayers()
        {
            return _players.Count;
        }

        public List<PlayerDescription> getAllPlayersDescriptions()
        {
            return _players.ConvertAll(x => x.Description);
        }

        public List<string> getAllPlayersIDs()
        {
            return _players.ConvertAll(x => x.Id);
        }

        public List<Player> getAllPlayersInClub(string clubId)
        {
            return _players.FindAll(x => x.ClubId == clubId);
        }

        public List<Player> getAllPlayersInPosition(PlayerPosition position)
        {
            return _players.FindAll(x => x.Position == position);
        }

        public List<Player> getAllPlayersInPositionAtClub(PlayerPosition position, string clubId)
        {
            return _players.FindAll(x => x.ClubId == clubId).FindAll(x => x.Position == position);
        }

        public string getNewID()
        {
            return Guid.NewGuid().ToString();
        }

        public List<Player> getAllPlayers(string name)
        {
            return new List<Player>(_players);
        }

        public List<Player> getPlayersWithName(string name)
        {
            return _players.FindAll(x => x.Name == name);
        }

        public Player getPlayerByID(string playerId)
        {
            return _players.Find(x => x.Id == playerId);
        }

        public string getPlayersClubId(string playerId)
        {
            var player = _players.Find(x => x.Id == playerId);
            if (player == null)
                return null;
            return player.ClubId;
        }
    }
}
