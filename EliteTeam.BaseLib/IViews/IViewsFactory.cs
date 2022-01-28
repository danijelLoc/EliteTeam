using System;
using EliteTeam.BaseLib;
namespace EliteTeam.BaseLib
{
    public interface IViewsFactory
    {
        public IPlayersListView PlayersListView();
        public ICreatePlayerView PlayerCreatorView();
        public IUpdatePlayerView PlayerUpdaterView();
        public IClubsListView ClubsListView();
        public ICreateClubView ClubCreatorView();
        public IUpdateClubView ClubUpdaterView();
        public ICreateMatchView MatchCreatorView();
        public IMatchView MatchView();
        public IMatchResultsListView MatchResultsListView();
    }
}
