using System;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class MainFormController
    {
        private readonly IWindowFormsFactory _formsFactory = null;
        public MainFormController(IWindowFormsFactory windowFormsFactory)
        {
            _formsFactory = windowFormsFactory;
        }

        public void RunAll()
        {
            Squad squad1 = PlayerFactory.GetRandomSquad();
            Squad squad2 = PlayerFactory.GetRandomSquad();
            Manager manager1 = new Manager("Danijel", 23);
            Manager manager2 = new Manager("Paulo", 23);
            Club homeClub = new Club("Hajduk", "HAJ", squad1, manager1, Tactic.possesion);
            Club awayClub = new Club("Rijeka", "RIJ", squad2, manager2, Tactic.counterAttack);
            IMatchSimulator matchSimulator = new MyMatchSimulator();
            matchSimulator.Simulate(homeClub, awayClub);
        }
    }
}
