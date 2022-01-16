using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class DefenderAI : PlayerAI
    {
        public override void CalculateMoveWeights(Tactic tactic)
        {
            switch (tactic)
            {
                case Tactic.possesion:
                    // weights of choices
                    chooseToPassToDefence = 0.3;
                    chooseToPassToMidfield = 0.5;
                    chooseToPassToAttack = 0.17;
                    chooseToShoot = 0.03;
                    break;
                case Tactic.counterAttack:
                    chooseToPassToDefence = 0.1;
                    chooseToPassToMidfield = 0.49;
                    chooseToPassToAttack = 0.4;
                    chooseToShoot = 0.01;
                    break;
                default:
                    throw new ArgumentException();
            }

        }
    }
}