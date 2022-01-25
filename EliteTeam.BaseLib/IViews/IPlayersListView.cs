using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IPlayersListView
    {
        public void UpdateList();
        void ShowModaless(IPlayerController playerController, IMainFormController mainFormController);
    }
}
