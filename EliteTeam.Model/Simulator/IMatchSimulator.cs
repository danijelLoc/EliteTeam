using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public interface IMatchSimulator
    {
        void Simulate(Club homeClub, Club awayClub);
    }
}