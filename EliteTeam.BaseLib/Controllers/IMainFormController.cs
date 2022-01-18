using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.BaseLib
{
    public interface IMainFormController
    {
        public void ShowPlayers();
        public void ShowClubs();
        public void AddPlayer();
        public void AddClub();
        void EditPlayer(string playerId);
        void EditClub(string playerId);
    }
}
