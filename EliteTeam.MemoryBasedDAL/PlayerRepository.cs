using System;
using System.Collections.Generic;
using EliteTeam.Model;

namespace EliteTeam.MemoryBasedDAL
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<Player> _players;
        private static PlayerRepository _instance;
        public static PlayerRepository Shared
        {
            get
            {
                return _instance ?? (_instance = new PlayerRepository());
            }
        }

        private PlayerRepository()
        {
            _players = new List<Player>();
        }

        public void addPlayer(Player inPlayer)
        {
            if (_players.Find(x => x.Id == inPlayer.Id) != null)
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

        public List<Player> getAllPlayers()
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

        public List<Player> getAllFreeAgentPlayers()
        {
            return _players.FindAll(x => x.ClubId == null);
        }

        public void playerSignedForClub(string playerId, string clubId)
        {
            var player = _players.Find(x => x.Id == playerId);
            if (player == null) throw new ArgumentException();
            player.ClubId = clubId;
        }

        public void playersSignedForClub(List<string> playerIds, string clubId)
        {
            foreach (string playerId in playerIds)
                playerSignedForClub(playerId, clubId);
        }

        public void addPlayers(List<Player> inPlayers)
        {
            foreach (Player player in inPlayers)
                addPlayer(player);
        }

        public void playerFiredFromClub(string playerId, string clubId)
        {
            var player = _players.Find(x => x.Id == playerId);
            if (player == null) throw new ArgumentException();
            player.ClubId = null;
        }
    }
}
