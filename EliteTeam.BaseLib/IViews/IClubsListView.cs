using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IClubsListView : IView, IObserver
    {
        public void UpdateList();
        void ShowModaless(IClubController clubController, IMainController mainController, ISubject clubsListSubject);
    }
}
