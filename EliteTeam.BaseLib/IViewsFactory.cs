using System;
using EliteTeam.BaseLib;
namespace EliteTeam.BaseLib
{
    public interface IViewsFactory
    {
        public IPlayersListView PlayersListView();
        public ICreatePlayerView PlayerCreatorView();
        public IClubsListView ClubsListView();
        public ICreateClubView ClubCreatorView();
        public ICreateMatchView MatchCreatorView();
        public IMatchView MatchView();
        public IMatchResultsListView MatchResultsListView();
    }
}
