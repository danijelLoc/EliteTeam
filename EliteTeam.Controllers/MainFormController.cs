using System;
using System.Collections.Generic;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class MainFormController
    {
        private readonly IWindowFormsFactory _formsFactory = null;
        private readonly IPlayerRepository _playerRepository = null;
        public MainFormController(IWindowFormsFactory windowFormsFactory, IPlayerRepository playerRepository)
        {
            _formsFactory = windowFormsFactory;
            _playerRepository = playerRepository;
        }

        public void RunAll()
        {
            List<Player> squad1 = PlayerFactory.GetRandomSquad();
            List<Player> squad2 = PlayerFactory.GetRandomSquad();
            _playerRepository.addPlayers(squad1);
            _playerRepository.addPlayers(squad2);
            Club homeClub = new Club("Dinamo", "DIN", "Danijel", Tactic.possesion);
            Club awayClub = new Club("Rijeka", "RIJ", "Paulo", Tactic.counterAttack);
            homeClub.SignPlayers(squad1.ConvertAll(x => x.Id));
            awayClub.SignPlayers(squad2.ConvertAll(x => x.Id));
            _playerRepository.playersSignedForClub(squad1.ConvertAll(x => x.Id), homeClub.Id);
            _playerRepository.playersSignedForClub(squad2.ConvertAll(x => x.Id), awayClub.Id);

            IMatchSimulator matchSimulator = new MyMatchSimulator();
            matchSimulator.Simulate(homeClub, awayClub, _playerRepository, null, null);
        }

    }
}
