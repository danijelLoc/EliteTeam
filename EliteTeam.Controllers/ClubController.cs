using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.BaseLib;
using EliteTeam.Model;

namespace EliteTeam.Controllers
{
    public class ClubController : IClubController
    {

        private IClubRepository _clubRepository;
        private IPlayerRepository _playerRepository;
        public ClubController(IClubRepository clubRepository, IPlayerRepository playerRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }
        public List<Club> GetClubs()
        {
            return _clubRepository.getAllClubs();
        }

        public List<Player> GetClubSquad(string clubId)
        {
            return _playerRepository.getAllPlayersInClub(clubId);
        }

        public List<Player> GetFreeAgentPlayers()
        {
            return _playerRepository.getAllFreeAgentPlayers();
        }

        public void RemovePlayerFromClubSquad(string clubId, string playerId)
        {
            _clubRepository.clubFiredPlayer(playerId, clubId);
            _playerRepository.playerFiredFromClub(playerId, clubId);
        }

        public void AddPlayerToClubSquad(string clubId, string playerId)
        {
            _clubRepository.clubSignedPlayer(playerId, clubId);
            _playerRepository.playerSignedForClub(playerId, clubId);
        }

        public object[] GetTacticOptions()
        {
            return new object[2] { Tactic.counterAttack, Tactic.possesion };
        }

        public void TryToRemoveClub(IUpdateClubView inView, string clubId)
        {
            try
            {
                var squad = _playerRepository.getAllPlayersInClub(clubId);
                _clubRepository.clubFiredAllPlayers(clubId);
                foreach (Player player in squad)
                    _playerRepository.playerFiredFromClub(player.Id, clubId);
                _clubRepository.deleteClub(clubId);
                inView.CloseView();
            }
            catch (Exception exc)
            {
                inView.ShowMessage(exc.Message);
            }
        }

        public void ShowAddNewClub(ICreateClubView inView)
        {
            inView.ShowModaless(this);
        }

        public void ShowUpdateClub(IUpdateClubView inView, Club club)
        {
            inView.ShowModaless(this, club);
        }

        public void ShowClubs(IClubsListView inView, IMainController mainController)
        {
            inView.ShowModaless(this, mainController);
        }

        public void TryToAddClub(ICreateClubView inView)
        {
            try
            {
                Tactic tactic = (Tactic)Enum.Parse(typeof(Tactic), inView.Tactic);
                Club newClub = new Club(inView.ClubName, inView.ShortClubName, inView.ManagerName, tactic);

                // register club
                _clubRepository.addClub(newClub);

                // sign players to new club
                List<Player> squad = inView.SquadPlayers;
                foreach (Player player in squad)
                {
                    _clubRepository.clubSignedPlayer(player.Id, newClub.Id);
                    _playerRepository.playerSignedForClub(player.Id, newClub.Id);
                }
                inView.CloseView();
            }
            catch (Exception exc)
            {
                inView.ShowMessage(exc.Message);
            }
        }
        public void TryToUpdateClub(IUpdateClubView inView, Club oldClubInfo)
        {
            try
            {
                // update basic info
                Tactic tactic = (Tactic)Enum.Parse(typeof(Tactic), inView.Tactic);
                oldClubInfo.ClubManager = inView.ManagerName;
                oldClubInfo.Name = inView.ClubName;
                oldClubInfo.ShortName = inView.ShortClubName;
                oldClubInfo.Tactic = tactic;

                // update squad, fire old squad, sign new ones
                foreach (String playerId in oldClubInfo.ClubSquad)
                {
                    _clubRepository.clubFiredPlayer(playerId, oldClubInfo.Id);
                    _playerRepository.playerFiredFromClub(playerId, oldClubInfo.Id);
                }
                List<Player> squad = inView.SquadPlayers;
                foreach (Player player in squad)
                {
                    _clubRepository.clubSignedPlayer(player.Id, oldClubInfo.Id);
                    _playerRepository.playerSignedForClub(player.Id, oldClubInfo.Id);
                }
                inView.CloseView();
            }
            catch (Exception exc)
            {
                inView.ShowMessage(exc.Message);
            }
        }

    }
}
