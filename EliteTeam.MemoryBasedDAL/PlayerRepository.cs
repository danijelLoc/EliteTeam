using System;
using System.Collections.Generic;
using EliteTeam.Model;

namespace EliteTeam.MemoryBasedDAL
{
    public class PlayerRepository : Subject, IPlayerRepository
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
                throw new PlayerTakenIdException();
            if (inPlayer.PlayerAI == null)
                throw new PlayerAIMissingException();
            _players.Add(inPlayer);
            NotifyObservers();
        }

        public void deletePlayer(string inPlyerID)
        {
            int i = _players.RemoveAll(x => x.Id == inPlyerID);
            if (i == 0) throw new PlayerDeletedException();
            NotifyObservers();
        }

        public bool doesPlayerExists(string name)
        {
            return _players.Find(x => x.Name == name) != null;
        }

        public int getNumberOfPlayers()
        {
            return _players.Count;
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
                throw new PlayerDeletedException();
            return player.ClubId;
        }

        public List<Player> getAllFreeAgentPlayers()
        {
            return _players.FindAll(x => x.ClubId == null);
        }

        public void playerSignedForClub(string playerId, string clubId)
        {
            var player = _players.Find(x => x.Id == playerId);
            if (player == null) throw new PlayerDeletedException();
            if (player.ClubId != null) throw new PlayerIsTakenException();
            player.ClubId = clubId;
            NotifyObservers();
        }

        public void playersSignedForClub(List<string> playerIds, string clubId)
        {
            foreach (string playerId in playerIds)
                playerSignedForClub(playerId, clubId);
            NotifyObservers();
        }

        public void addPlayers(List<Player> inPlayers)
        {
            foreach (Player player in inPlayers)
                addPlayer(player);
            NotifyObservers();
        }

        public void playerLeavesClub(string playerId)
        {
            var player = _players.Find(x => x.Id == playerId);
            if (player == null) throw new PlayerDeletedException();
            if (player.ClubId == null) throw new PlayerIsFreeAgentException();
            player.ClubId = null;
            NotifyObservers();
        }

        public void updatePlayerStatsAndName(string plyerID, Stats stats, string name)
        {
            var player = _players.Find(x => x.Id == plyerID);
            if (player == null) throw new PlayerDeletedException();
            player.Name = name;
            player.Stats = stats;
            NotifyObservers();
        }

        public void deleteAllPlayers()
        {
            _players.Clear();
            NotifyObservers();
        }
    }
}
