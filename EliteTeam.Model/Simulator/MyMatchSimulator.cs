using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class MyMatchSimulator : IMatchSimulator
    {
        private Random r = MathHelper.r;
        private Club homeClub;
        private Club awayClub;

        private IPlayerRepository playerRepository;
        private Player playerInPossesion;
        private Club clubInPossesion;
        private Club clubOutOfPossesion;
        private MatchSquad squadInPossesion;
        private MatchSquad squadOutOfPossesion;
        private MatchSquad squadThatStartedMatch;

        Dictionary<string, int> score = new Dictionary<string, int>();

        public void Simulate(Club homeClub, Club awayClub, IPlayerRepository playerRepository, IClubRepository clubRepository, IMatchResultRepository matchRepository)
        {
            this.playerRepository = playerRepository;
            this.homeClub = homeClub;
            this.awayClub = awayClub;
            MatchKickOff();
            for (int i = 0; i < 45; i++)
                NextAction();
            HalfTime();
            for (int i = 0; i < 45; i++)
                NextAction();
            FullTime();
        }

        public double CalculatePlayerActionSuccessProbability(PlayerAction playerAction)
        {
            double successProbability = 0;
            double oppositionGoalkeeping = 1.0 * squadOutOfPossesion.GoalKeeper.Stats.Shooting / Stats.MaxValue;
            double shooting = 1.0 * playerInPossesion.Stats.Shooting / Stats.MaxValue;
            double passing = 1.0 * playerInPossesion.Stats.Passing / Stats.MaxValue;
            switch (playerAction.Type)
            {
                case PlayerActionType.shoot:
                    successProbability = shooting / (shooting + oppositionGoalkeeping);
                    successProbability *= 0.5; // its hard to score a goal in football...
                    break;
                case PlayerActionType.passToAttack:
                    double oppositionMidDefBallRecovery = 0.001;
                    oppositionMidDefBallRecovery += squadOutOfPossesion.Defence.Sum(x => x.Stats.Interceptions);
                    oppositionMidDefBallRecovery += squadOutOfPossesion.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidDefBallRecovery = oppositionMidDefBallRecovery / ((squadOutOfPossesion.Defence.Count + squadOutOfPossesion.Midfield.Count) * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidDefBallRecovery);
                    successProbability *= 1.2; // interceptions are not that frequent, passing made more accurate
                    break;
                case PlayerActionType.passToMidfield:
                    double oppositionMidfieldBallRecovery = 0.001;
                    oppositionMidfieldBallRecovery += squadOutOfPossesion.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidfieldBallRecovery = oppositionMidfieldBallRecovery / (squadOutOfPossesion.Midfield.Count * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidfieldBallRecovery);
                    successProbability *= 1.3;
                    break;
                case PlayerActionType.passToDefence:
                    double oppositionMidAttBallRecovery = 0.001;
                    oppositionMidAttBallRecovery += squadOutOfPossesion.Attack.Sum(x => x.Stats.Interceptions);
                    oppositionMidAttBallRecovery += squadOutOfPossesion.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidAttBallRecovery = oppositionMidAttBallRecovery / ((squadOutOfPossesion.Attack.Count + squadOutOfPossesion.Midfield.Count) * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidAttBallRecovery);
                    successProbability *= 1.5;
                    break;
                case PlayerActionType.passToGoalkeeper:
                    double oppositionAttackBallRecovery = 0.001;
                    oppositionAttackBallRecovery += squadOutOfPossesion.Attack.Sum(x => x.Stats.Interceptions);
                    oppositionAttackBallRecovery = oppositionAttackBallRecovery / (squadOutOfPossesion.Attack.Count * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionAttackBallRecovery);
                    successProbability *= 1.5;
                    break;
            }
            return successProbability;
        }

        public void NextAction()
        {
            PlayerAction action = playerInPossesion.PlayerAI.TakeAction(clubInPossesion.Tactic);
            double successProbability = CalculatePlayerActionSuccessProbability(action);
            double randomNum = r.NextDouble();
            Player playerToTakeTheBall;
            if (randomNum < successProbability)
            {
                // success
                switch (action.Type)
                {
                    case PlayerActionType.shoot:
                        System.Diagnostics.Debug.WriteLine("\t\t" + playerInPossesion.Name + "(" + clubInPossesion.ShortName + ")" + " scored a goal !!");
                        score[clubInPossesion.Id] += 1;
                        GoalKickOff();
                        break;
                    case PlayerActionType.passToAttack:
                        // TODO disable player pass to himself !! loop !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        playerToTakeTheBall = squadInPossesion.Attack[r.Next(squadInPossesion.Attack.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToMidfield:
                        playerToTakeTheBall = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToDefence:
                        playerToTakeTheBall = squadInPossesion.Defence[r.Next(squadInPossesion.Defence.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToGoalkeeper:
                        PassedTheBall(squadInPossesion.GoalKeeper);
                        break;
                }
            }
            else
            {
                // failure
                switch (action.OpositionReactionType)
                {
                    case PossibleReactionType.oppositionGoalKeeperMakesASave:
                        MakesASave(squadOutOfPossesion.GoalKeeper);
                        break;
                    case PossibleReactionType.oppositionDefenceTakesTheBall:
                        playerToTakeTheBall = squadOutOfPossesion.Defence[r.Next(squadOutOfPossesion.Defence.Count)];
                        InterceptedTheBall(playerToTakeTheBall);
                        break;
                    case PossibleReactionType.oppositionMidfieldTakesTheBall:
                        playerToTakeTheBall = squadOutOfPossesion.Midfield[r.Next(squadOutOfPossesion.Midfield.Count)];
                        InterceptedTheBall(playerToTakeTheBall);
                        break;
                    case PossibleReactionType.oppositionAttackTakesTheBall:
                        playerToTakeTheBall = squadOutOfPossesion.Attack[r.Next(squadOutOfPossesion.Attack.Count)];
                        InterceptedTheBall(playerToTakeTheBall);
                        break;
                }
            }
        }

        private void PassedTheBall(Player playerToTakeTheBall)
        {
            if (playerInPossesion.Id == playerToTakeTheBall.Id) return;
            System.Diagnostics.Debug.WriteLine("..." + playerInPossesion.Name + "(" + clubInPossesion.ShortName + ":" + playerInPossesion.Position + ")" +
                " passed ball to " + playerToTakeTheBall.Name + "(" + clubInPossesion.ShortName + ":" + playerToTakeTheBall.Position + ")");
            playerInPossesion = playerToTakeTheBall;
        }

        private void InterceptedTheBall(Player playerToTakeTheBall)
        {
            System.Diagnostics.Debug.WriteLine(" X " + playerToTakeTheBall.Name + "(" + clubOutOfPossesion.ShortName + ":" + playerToTakeTheBall.Position + ")" +
                " intercepted ball from " + playerInPossesion.Name + "(" + playerInPossesion.Position + ")");
            ChangePossesion();
            playerInPossesion = playerToTakeTheBall;
        }

        private void MakesASave(Player playerToMakeASave)
        {
            System.Diagnostics.Debug.WriteLine("\t" + playerToMakeASave.Name + "(" + clubOutOfPossesion.ShortName + ")" +
                " saves a shot from " + playerInPossesion.Name + "(" + playerInPossesion.Position + ") !");
            ChangePossesion();
            playerInPossesion = playerToMakeASave;
        }

        private void ChangePossesion()
        {
            MatchSquad temp = squadInPossesion;
            squadInPossesion = squadOutOfPossesion;
            squadOutOfPossesion = temp;
        }

        public void MatchKickOff()
        {
            score[homeClub.Id] = 0;
            score[awayClub.Id] = 0;
            System.Diagnostics.Debug.WriteLine("MATCH STARTS!");
            double p = r.NextDouble();
            if (p >= 0.5)
            {
                clubInPossesion = homeClub;
                squadInPossesion = new MatchSquad(playerRepository, homeClub.Id);
                clubOutOfPossesion = awayClub;
                squadOutOfPossesion = new MatchSquad(playerRepository, awayClub.Id);
            }
            else
            {
                clubInPossesion = awayClub;
                squadInPossesion = new MatchSquad(playerRepository, awayClub.Id);
                clubOutOfPossesion = homeClub;
                squadOutOfPossesion = new MatchSquad(playerRepository, homeClub.Id);
            }
            squadThatStartedMatch = squadInPossesion;
            System.Diagnostics.Debug.WriteLine(clubInPossesion.Name + " starts the game.");
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
        }

        public void GoalKickOff()
        {
            System.Diagnostics.Debug.WriteLine("Match rasumes!");
            ChangePossesion();
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
        }

        public void HalfTime()
        {
            System.Diagnostics.Debug.WriteLine("\n\nHALF TIME!");
            System.Diagnostics.Debug.WriteLine("Result = " + homeClub.ShortName + " " + score[homeClub.Id] + " : " + awayClub.ShortName + " " + score[awayClub.Id]);
            System.Diagnostics.Debug.WriteLine("Match rasumes!\n\n");
            if (homeClub.Id == squadThatStartedMatch.ClubId)
            {
                clubInPossesion = awayClub;
                squadInPossesion = new MatchSquad(playerRepository, awayClub.Id);
                clubOutOfPossesion = homeClub;
                squadOutOfPossesion = new MatchSquad(playerRepository, homeClub.Id);
            }
            else
            {
                clubInPossesion = homeClub;
                squadInPossesion = new MatchSquad(playerRepository, homeClub.Id);
                clubOutOfPossesion = awayClub;
                squadOutOfPossesion = new MatchSquad(playerRepository, awayClub.Id);
            }
            System.Diagnostics.Debug.WriteLine(clubInPossesion.Name + " continues the game");
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
        }

        public void FullTime()
        {
            System.Diagnostics.Debug.WriteLine("\n\nFINAL WHISTLE!");
            System.Diagnostics.Debug.WriteLine("MATCH IS FINSHED!");
            System.Diagnostics.Debug.WriteLine("Result = " + homeClub.Name + " " + score[homeClub.Id] + " : " + awayClub.Name + " " + score[awayClub.Id]);
        }
    }
}