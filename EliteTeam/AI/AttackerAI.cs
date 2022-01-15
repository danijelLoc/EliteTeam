using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam
{
    public class AttackerAI : PlayerAI
    {
        public override void CalculateMoveWeights(Tactic tactic)
        {
            switch (tactic)
            {
                case Tactic.possesion:
                    // weights of choices
                    chooseToPassToDefence = 0.01;
                    chooseToPassToMidfield = 0.1;
                    chooseToPassToAttack = 0.29;
                    chooseToShoot = 0.6;
                    break;
                case Tactic.counterAttack:
                    chooseToPassToDefence = 0.01;
                    chooseToPassToMidfield = 0.05;
                    chooseToPassToAttack = 0.14;
                    chooseToShoot = 0.8;
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }
}