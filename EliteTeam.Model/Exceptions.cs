using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EliteTeam.Model
{

    #region Base Exceptions

    [Serializable]
    public class EliteTeamBaseException : Exception
    {
        public EliteTeamBaseException(string message) : base(message) { }

    }

    [Serializable]
    public class ClubBaseException : EliteTeamBaseException
    {
        public ClubBaseException(string message) : base(message) { }
    }

    [Serializable]
    public class HumanBaseException : EliteTeamBaseException
    {
        public HumanBaseException(string message) : base(message) { }
    }

    [Serializable]
    public class PlayerBaseException : HumanBaseException
    {
        public PlayerBaseException(string message) : base(message) { }
    }

    [Serializable]
    public class MatchBaseException : EliteTeamBaseException
    {
        public MatchBaseException(string message) : base(message) { }
    }

    #endregion

    [Serializable]
    public class ClubTakenIdException : ClubBaseException
    {
        public ClubTakenIdException() : base("Club id already taken.") { }
    }

    [Serializable]
    public class ClubIdMissingException : ClubBaseException
    {
        public ClubIdMissingException() : base("Club with given id is not in repository.") { }
    }

    [Serializable]
    public class ClubTakenNameException : ClubBaseException
    {
        public ClubTakenNameException() : base("Club name already taken.") { }
    }

    [Serializable]
    public class ClubTakenShortNameException : ClubBaseException
    {
        public ClubTakenShortNameException() : base("Club short name already taken.") { }
    }

    [Serializable]
    public class ClubTakenManagerException : ClubBaseException
    {
        public ClubTakenManagerException() : base("Club manager already taken.") { }
    }

    [Serializable]
    public class ClubInvalidNameException : ClubBaseException
    {
        public ClubInvalidNameException() : base("Club name must be at least three characters long.") { }
    }
    [Serializable]
    public class ClubInvalidShortNameException : ClubBaseException
    {
        public ClubInvalidShortNameException() : base("Club short name must be three characters long.") { }
    }

    [Serializable]
    public class ClubPlayerMissingException : ClubBaseException
    {
        public ClubPlayerMissingException() : base("Player missing from club squad.") { }
    }

    [Serializable]
    public class PlayerTakenIdException : PlayerBaseException
    {
        public PlayerTakenIdException() : base("Player id already taken.") { }
    }

    [Serializable]
    public class PlayerIdMissingException : PlayerBaseException
    {
        public PlayerIdMissingException() : base("Player doesn't exist in repository.") { }
    }

    [Serializable]
    public class PlayerIsFreeAgentException : PlayerBaseException
    {
        public PlayerIsFreeAgentException() : base("Player doesn't play for any club.") { }
    }

    [Serializable]
    public class PlayerIsTakenException : PlayerBaseException
    {
        public PlayerIsTakenException() : base("Player plays for a club and cannot be signed before resignation.") { }
    }

    [Serializable]
    public class NegativeAgeException : HumanBaseException
    {
        public NegativeAgeException() : base("Age must be positive.") { }
    }

    [Serializable]
    public class PlayerAgeException : PlayerBaseException
    {
        public PlayerAgeException() : base("Player must be over 17(including) and below 43 year old.") { }
    }

    [Serializable]
    public class PlayerAIMissingException : PlayerBaseException
    {
        public PlayerAIMissingException() : base("Player must have AI.") { }
    }

    [Serializable]
    public class HumanNameLengthException : HumanBaseException
    {
        public HumanNameLengthException() : base("Human name must be at least 2 characters long.") { }
    }

    [Serializable]
    public class CountryNameLengthException : HumanBaseException
    {
        public CountryNameLengthException() : base("Country name must be at least 2 characters long.") { }
    }

    [Serializable]
    public class MatchResultTakenIdException : MatchBaseException
    {
        public MatchResultTakenIdException() : base("Match result id is taken.") { }
    }

    [Serializable]
    public class MatchSameClubsException : MatchBaseException
    {
        public MatchSameClubsException() : base("Selected same club twice, please select different clubs.") { }
    }

    [Serializable]
    public class MatchInvalidHomeSquad : MatchBaseException
    {
        public MatchInvalidHomeSquad() : base("Home match squad is not valid, 4-3-3 formation is not possible with given players or goalkeeper is missing.") { }
    }

    [Serializable]
    public class MatchInvalidAwaySquad : MatchBaseException
    {
        public MatchInvalidAwaySquad() : base("Away match squad is not valid,  4-3-3 formation is not possible with given players or goalkeeper is missing.") { }
    }

    [Serializable]
    public class NotEnoughClubsForMatchCreator : MatchBaseException
    {
        public NotEnoughClubsForMatchCreator() : base("There must be at least two clubs to create a match.") { }
    }
}
