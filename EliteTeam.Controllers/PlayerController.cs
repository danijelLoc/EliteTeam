using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class PlayerController
    {
        private IPlayerRepository _playerRepository;

        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void ShowPlayersTest()
        {
            System.Diagnostics.Debug.WriteLine(_playerRepository.getAllPlayersIDs());
        }

        public void AddNewAccount(ICreatePlayerView inForm, IPlayerRepository playerRepository)
        {
            if (inForm.ShowViewModal())
            {

            }
        }

        public void ShowPlayers(IPlayersListView inForm, IPlayerRepository playerRepository, IMainFormController mainController)
        {
            // dohvati sve accounte i proslijedi ih View-u
            List<Player> listPlayers = playerRepository.getAllPlayers();

            // zašto proslijeđujemo i mainController?
            // zato što na ovom View-u imamo "Add new account" i "Edit new account" funkcionalnost!
            inForm.ShowModaless(mainController, listPlayers);
        }
    }
}
