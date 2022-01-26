using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EliteTeam.Model;

namespace EliteTeam.BaseLib
{
    public interface ICreatePlayerView : IView
    {
        void ShowModaless(IPlayerController playerController);
        string PlayerName { get; }
        string Country { get; }
        int Age { get; }
        string Position { get; }

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
