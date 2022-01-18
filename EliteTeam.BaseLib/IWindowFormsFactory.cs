using System;
using EliteTeam.BaseLib;
namespace EliteTeam.BaseLib
{
    public interface IWindowFormsFactory
    {
        public IPlayersListView playersListForm();
        public IClubsListView clubsListForm();
        public ICreatePlayerView cretePlayerForm();
        public ICreateClubView creteClubForm();
    }
}
