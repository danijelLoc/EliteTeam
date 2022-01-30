using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{
    [Serializable]
    public class EliteTeamBaseException : Exception
    {
        public EliteTeamBaseException(string message) : base(message) { }
    }

    [Serializable]
    public class ClubTakenIdException : EliteTeamBaseException
    {
        public ClubTakenIdException() : base("Club id already taken.") { }
    }

    [Serializable]
    public class ClubIdMissingException : EliteTeamBaseException
    {
        public ClubIdMissingException() : base("Club with given id is not in repository.") { }
    }

    [Serializable]
    public class ClubTakenNameException : EliteTeamBaseException
    {
        public ClubTakenNameException() : base("Club name already taken.") { }
    }

    [Serializable]
    public class ClubTakenShortNameException : EliteTeamBaseException
    {
        public ClubTakenShortNameException() : base("Club short name already taken.") { }
    }

    [Serializable]
    public class ClubTakenManagerException : EliteTeamBaseException
    {
        public ClubTakenManagerException() : base("Club manager already taken.") { }
    }

    [Serializable]
    public class ClubInvalidNameException : EliteTeamBaseException
    {
        public ClubInvalidNameException() : base("Club name must be at least three characters long.") { }
    }
    [Serializable]
    public class ClubInvalidShortNameException : EliteTeamBaseException
    {
        public ClubInvalidShortNameException() : base("Club short name must be three characters long.") { }
    }

    [Serializable]
    public class ClubPlayerMissingException : EliteTeamBaseException
    {
        public ClubPlayerMissingException() : base("Player missing from club squad.") { }
    }

    [Serializable]
    public class PlayerTakenIdException : EliteTeamBaseException
    {
        public PlayerTakenIdException() : base("Player id already taken.") { }
    }

    [Serializable]
    public class PlayerDeletedException : EliteTeamBaseException
    {
        public PlayerDeletedException() : base("Player doesn't exist in repository.") { }
    }

    [Serializable]
    public class PlayerIsFreeAgentException : EliteTeamBaseException
    {
        public PlayerIsFreeAgentException() : base("Player doesn't play for any club.") { }
    }

    [Serializable]
    public class PlayerIsTakenException : EliteTeamBaseException
    {
        public PlayerIsTakenException() : base("Player plays for a club and cannot be signed before resignation.") { }
    }

    [Serializable]
    public class NegativeAgeException : EliteTeamBaseException
    {
        public NegativeAgeException() : base("Age must be positive.") { }
    }

    [Serializable]
    public class PlayerAgeException : EliteTeamBaseException
    {
        public PlayerAgeException() : base("Player must be over 16 and below 43 year old.") { }
    }

    [Serializable]
    public class PlayerAIMissingException : EliteTeamBaseException
    {
        public PlayerAIMissingException() : base("Player must have AI.") { }
    }

    [Serializable]
    public class HumanNameLengthException : EliteTeamBaseException
    {
        public HumanNameLengthException() : base("Name must be at least 2 characters long.") { }
    }

    [Serializable]
    public class CountryNameLengthException : EliteTeamBaseException
    {
        public CountryNameLengthException() : base("Country name must be at least 2 characters long.") { }
    }

    [Serializable]
    public class MatchResultTakenIdException : EliteTeamBaseException
    {
        public MatchResultTakenIdException() : base("Match result id is taken.") { }
    }

    [Serializable]
    public class MatchSameClubsException : EliteTeamBaseException
    {
        public MatchSameClubsException() : base("Selected same club twice, please select different clubs.") { }
    }

    [Serializable]
    public class MatchInvalidHomeSquad : EliteTeamBaseException
    {
        public MatchInvalidHomeSquad() : base("Home match squad is not valid, lack of outfield players or goalkeeper missing.") { }
    }

    [Serializable]
    public class MatchInvalidAwaySquad : EliteTeamBaseException
    {
        public MatchInvalidAwaySquad() : base("Away match squad is not valid, lack of outfield players or goalkeeper missing.") { }
    }

    [Serializable]
    public class NotEnoughClubsForMatchCreator : EliteTeamBaseException
    {
        public NotEnoughClubsForMatchCreator() : base("There must be at least two clubs to create a match.") { }
    }
}
