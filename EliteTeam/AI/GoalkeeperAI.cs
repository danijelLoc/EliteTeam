using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam
{
    public class GoalkeeperAI : PlayerAI
    {
        public override void CalculateMoveWeights(Tactic tactic)
        {
            switch (tactic)
            {
                case Tactic.possesion:
                    // weights of choices
                    chooseToPassToDefence = 0.5;
                    chooseToPassToMidfield = 0.35;
                    chooseToPassToAttack = 0.149;
                    chooseToShoot = 0.001;
                    break;
                case Tactic.counterAttack:
                    chooseToPassToDefence = 0.15;
                    chooseToPassToMidfield = 0.349;
                    chooseToPassToAttack = 0.5;
                    chooseToShoot = 0.001;
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }
}