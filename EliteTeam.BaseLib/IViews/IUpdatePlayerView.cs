using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface IUpdatePlayerView : IView
    {
        void ShowModaless(IPlayerController playerController, PlayerDescriptor player);
        string PlayerName { get; }
        bool Resigned { get; }

        int Passing { get; }
        int Shooting { get; }
        int Dribling { get; }
        int Speed { get; }

        int Strenght { get; }
        int Interceptions { get; }
        int Goalkeeping { get; }
        int Stamina { get; }
    }
}
