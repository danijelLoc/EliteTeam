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

        public ClubController(IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public List<Club> GetClubs()
        {
            return _clubRepository.getAllClubs();
        }

        public object[] getTacticOptions()
        {
            return new object[2] { Tactic.counterAttack, Tactic.possesion };
        }

        public void RemoveClub(string clubId)
        {
            _clubRepository.deleteClub(clubId);
        }

        public void ShowAddNewClub(ICreateClubView inView)
        {
            inView.ShowModaless(this);
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
                _clubRepository.addClub(newClub);
                inView.CloseView();
            }
            catch (Exception exc)
            {
                inView.ShowMessage(exc.Message);
            }
        }
    }
}
