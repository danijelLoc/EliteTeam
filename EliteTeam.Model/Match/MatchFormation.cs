using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model

{
    public struct MatchFormation
    {
        public int NumOfDefenders { get; }
        public int NumOfMidfielders { get; }
        public int NumOfAttackers { get; }

        public MatchFormation(int numOfDefenders, int numOfMidfielders, int numOfAttackers)
        {
            if (numOfAttackers + numOfDefenders + numOfMidfielders != 10)
                throw new ArgumentException("Number of outfield players must be 10 in any formation!");
            NumOfDefenders = numOfDefenders;
            NumOfMidfielders = numOfMidfielders;
            NumOfAttackers = numOfAttackers;
        }
    }
}
