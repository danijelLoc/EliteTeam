using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IClubController
    {
        public List<Club> GetClubs();
        public object[] getTacticOptions();
        public void RemoveClub(string clubId);
        public void ShowAddNewClub(ICreateClubView inForm);
        public void TryToAddClub(ICreateClubView inForm);
        public void ShowClubs(IClubsListView inForm, IMainController mainController);
    }
}
