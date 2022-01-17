using System;
using EliteTeam.BaseLib;
namespace EliteTeam.BaseLib
{
    public interface IWindowFormsFactory
    {
        public IPlayersListView playersListForm();
        public ICreatePlayerView cretePlayerForm();
    }
}
