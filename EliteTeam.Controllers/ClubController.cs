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
        public List<ClubDescriptor> GetClubs()
        {
            return _clubRepository.getAllClubs().ConvertAll(x => new ClubDescriptor(x));
        }

        public List<PlayerDescriptor> GetClubSquad(string clubId)
        {
            return _playerRepository.getAllPlayersInClub(clubId).ConvertAll(x => new PlayerDescriptor(x));
        }

        public List<PlayerDescriptor> GetFreeAgentPlayers()
        {
            return _playerRepository.getAllFreeAgentPlayers().ConvertAll(x => new PlayerDescriptor(x));
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

        public void RemoveClub(IUpdateClubView inView, string clubId)
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

        public void ShowUpdateClub(IUpdateClubView inView, ClubDescriptor club)
        {
            inView.ShowModaless(this, club);
        }

        public void ShowClubs(IClubsListView inView, IMainController mainController)
        {
            // repository passed as ISubject
            inView.ShowModaless(this, mainController, _clubRepository);
        }

        public void AddClub(ICreateClubView inView)
        {
            Tactic tactic = (Tactic)Enum.Parse(typeof(Tactic), inView.Tactic);
            Club newClub = new Club(inView.ClubName, inView.ShortClubName, inView.ManagerName, tactic);

            // register club
            _clubRepository.addClub(newClub);

            // sign players to new club
            List<PlayerDescriptor> squad = inView.SquadPlayers;
            foreach (PlayerDescriptor player in squad)
            {
                _clubRepository.clubSignedPlayer(player.Id, newClub.Id);
                _playerRepository.playerSignedForClub(player.Id, newClub.Id);
            }
            inView.CloseView();
        }
        public void UpdateClub(IUpdateClubView inView, ClubDescriptor oldClubInfo)
        {
            // update basic info
            Tactic tactic = (Tactic)Enum.Parse(typeof(Tactic), inView.Tactic);
            ClubDescriptor newInfo = new ClubDescriptor(oldClubInfo.Id, oldClubInfo.ClubSquad, inView.ClubName, inView.ManagerName, tactic, inView.ShortClubName);
            _clubRepository.updateClub(oldClubInfo.Id, newInfo);

            // update squad, fire old squad, sign new ones
            var oldClubSquad = new List<string>(oldClubInfo.ClubSquad);
            List<PlayerDescriptor> newSquad = inView.SquadPlayers;
            foreach (String playerId in oldClubSquad)
            {
                _clubRepository.clubFiredPlayer(playerId, oldClubInfo.Id);
                _playerRepository.playerFiredFromClub(playerId, oldClubInfo.Id);
            }
            foreach (PlayerDescriptor player in newSquad)
            {
                _clubRepository.clubSignedPlayer(player.Id, oldClubInfo.Id);
                _playerRepository.playerSignedForClub(player.Id, oldClubInfo.Id);
            }

            inView.CloseView();

        }

    }
}
