using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public interface ICreateMatchView : IView
    {
        void ShowModaless(IMatchController matchController, IMainFormController mainFormController);
        public string HomeClubName { get; }
        public string AwayClubName { get; }
    }
}
