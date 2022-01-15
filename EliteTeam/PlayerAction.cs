using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam
{
    public struct PlayerAction
    {
        public PlayerActionType Type { get; set; }
        // if action fails
        public PossibleReactionType OpositionReactionType { get; set; }

        public PlayerAction(PlayerActionType type, PossibleReactionType opositionReactionType)
        {
            Type = type;
            OpositionReactionType = opositionReactionType;
        }
    }
}