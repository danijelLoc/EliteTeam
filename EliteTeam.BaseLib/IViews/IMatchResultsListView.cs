using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public interface IMatchResultsListView : IView
    {
        void ShowModaless(IMatchController matchController, IMainController mainController);
    }
}
