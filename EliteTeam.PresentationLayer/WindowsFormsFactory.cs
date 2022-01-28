using System;
using EliteTeam.BaseLib;

namespace EliteTeam.PresentationLayer
{
    public class WindowsFormsFactory : IViewsFactory
    {
        public IPlayersListView PlayersListView()
        {
            return new frmPlayersList();
        }

        public ICreatePlayerView PlayerCreatorView()
        {
            return new frmCreatePlayer();
        }

        public IClubsListView ClubsListView()
        {
            return new frmClubList();
        }

        public ICreateClubView ClubCreatorView()
        {
            return new frmCreateClub();
        }

        public ICreateMatchView MatchCreatorView()
        {
            return new frmCreateMatch();
        }

        public IMatchView MatchView()
        {
            return new frmMatch();
        }

        public IMatchResultsListView MatchResultsListView()
        {
            return new frmMatchResultsList();
        }

        public IUpdateClubView ClubUpdaterView()
        {
            return new frmUpdateClub();
        }

        public IUpdatePlayerView PlayerUpdaterView()
        {
            return new frmUpdatePlayer();
        }
    }
}
