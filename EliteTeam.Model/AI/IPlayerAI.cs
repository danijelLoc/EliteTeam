using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public abstract class IPlayerAI
    {
        protected Double chooseToPassToDefence;
        protected Double chooseToPassToMidfield;
        protected Double chooseToPassToAttack;
        protected Double chooseToShoot;

        public abstract void CalculateMoveWeights(Tactic tactic);
        public PlayerAction TakeAction(Tactic tactic)
        {
            CalculateMoveWeights(tactic);
            Double p = MathHelper.r.NextDouble();
            if (p >= chooseToPassToDefence + chooseToPassToMidfield + chooseToPassToAttack)
                return new PlayerAction(PlayerActionType.shoot, PossibleReactionType.oppositionGoalKeeperMakesASave);
            else if (p >= chooseToPassToDefence + chooseToPassToMidfield)
                return new PlayerAction(PlayerActionType.passToAttack, PossibleReactionType.oppositionDefenceTakesTheBall);
            else if (p >= chooseToPassToDefence)
                return new PlayerAction(PlayerActionType.passToMidfield, PossibleReactionType.oppositionMidfieldTakesTheBall);
            else
                return new PlayerAction(PlayerActionType.passToDefence, PossibleReactionType.oppositionAttackTakesTheBall);
        }
    }
}