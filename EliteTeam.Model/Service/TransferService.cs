using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public class TransferService : ITransferService
    {
        private IClubRepository _clubRepository;
        private IPlayerRepository _playerRepository;
        public TransferService(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }

        public void AddPlayerToClubSquad(string clubId, string playerId)
        {
            if (_clubRepository.getClubByID(clubId) == null)
                throw new ClubIdMissingException();
            var player = _playerRepository.getPlayerByID(playerId);
            if (player == null)
                throw new PlayerIdMissingException();
            if (player.ClubId != null)
                throw new PlayerIsTakenException();
            _clubRepository.clubSignedPlayer(playerId, clubId);
            _playerRepository.playerSignedForClub(playerId, clubId);
        }

        public void RemovePlayerFromClubSquad(string clubId, string playerId)
        {
            if (_clubRepository.getClubByID(clubId) == null)
                throw new ClubIdMissingException();
            var player = _playerRepository.getPlayerByID(playerId);
            if (player == null)
                throw new PlayerIdMissingException();
            if (player.ClubId == null)
                throw new PlayerIsFreeAgentException();
            _clubRepository.clubFiredPlayer(playerId, clubId);
            _playerRepository.playerLeavesClub(playerId);
        }
    }
}
