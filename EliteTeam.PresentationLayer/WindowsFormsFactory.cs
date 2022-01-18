using System;
using EliteTeam.BaseLib;

namespace EliteTeam.PresentationLayer
{
    public class WindowsFormsFactory : IWindowFormsFactory
    {
        public IPlayersListView playersListForm()
        {
            return new frmPlayersList();
        }

        public ICreatePlayerView cretePlayerForm()
        {
            return new frmCreatePlayer();
        }

        public IClubsListView clubsListForm()
        {
            return new frmClubList();
        }

        public ICreateClubView creteClubForm()
        {
            return new frmCreateClub();
        }
    }
}
