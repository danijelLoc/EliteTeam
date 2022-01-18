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

        public void ShowAddNewClub(ICreateClubView inForm)
        {
            inForm.ShowModaless(this);
        }

        public void ShowClubs(IClubsListView inForm, IMainFormController mainFormController)
        {
            inForm.ShowModaless(this, mainFormController);
        }

        public void TryToAddClub(ICreateClubView inForm)
        {
            Tactic tactic = (Tactic)Enum.Parse(typeof(Tactic), inForm.Tactic);
            Club newClub = new Club(inForm.ClubName, inForm.ShortClubName, inForm.ManagerName, tactic);
            _clubRepository.addClub(newClub);
            inForm.CloseView();
        }
    }
}
