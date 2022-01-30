using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    public interface ITransferService
    {
        public void RemovePlayerFromClubSquad(string clubId, string playerId);
        public void AddPlayerToClubSquad(string clubId, string playerId);
    }
}
