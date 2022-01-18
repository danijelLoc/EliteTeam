using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public interface IClubsListView
    {
        public void UpdateList();
        void ShowModaless(IClubController clubController, IMainFormController mainFormController);
    }
}
