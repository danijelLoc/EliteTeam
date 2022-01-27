using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class MidfielderAI : IPlayerAI
    {
        public override void CalculateMoveWeights(Tactic tactic)
        {
            switch (tactic)
            {
                case Tactic.possesion:
                    // weights of choices
                    chooseToPassToDefence = 0.1;
                    chooseToPassToMidfield = 0.65;
                    chooseToPassToAttack = 0.2;
                    chooseToShoot = 0.05;
                    break;
                case Tactic.counterAttack:
                    chooseToPassToDefence = 0.05;
                    chooseToPassToMidfield = 0.2;
                    chooseToPassToAttack = 0.65;
                    chooseToShoot = 0.1;
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }
}