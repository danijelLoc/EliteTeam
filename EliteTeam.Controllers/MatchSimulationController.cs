using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EliteTeam.Model;
using EliteTeam.BaseLib;

namespace EliteTeam.Controllers
{
    public class MatchSimulationController : IMatchSimulationController
    {
        public readonly int halfTimeMinute = 45;
        public readonly int fullTimeMinute = 90;
        private int currentMinute;
        private int secondInCurrentMinute;
        private string CurrentTimeString
        {
            get
            {
                var minute = currentMinute < 10 ? "0" + currentMinute.ToString() : currentMinute.ToString();
                var second = secondInCurrentMinute < 10 ? "0" + secondInCurrentMinute.ToString() : secondInCurrentMinute.ToString();
                return minute + ":" + second;
            }
        }
        private Random r = MathHelper.r;

        private IMatchResultRepository _resultRepository;
        private IMatchView matchView;

        private MatchSquad homeSquad;
        private MatchSquad awaySquad;
        private MatchSquad squadInPossesion;
        private MatchSquad squadOutOfPossesion;
        private MatchSquad squadThatStartedMatch;
        private Player playerInPossesion;

        private DateTime kickOffTime;
        private Dictionary<string, int> score = null;

        public MatchSimulationController(IMatchResultRepository resultRepository)
        {
            _resultRepository = resultRepository;
        }

        public void CreateSimulation(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad)
        {
            score = new Dictionary<string, int>();
            this.homeSquad = homeSquad;
            this.awaySquad = awaySquad;
            this.matchView = matchView;
            MatchKickOff();
        }

        public void NextAction(IMatchView matchView, int currentMinute, int secondInCurrentMinute)
        {
            this.currentMinute = currentMinute;
            this.secondInCurrentMinute = secondInCurrentMinute;
            if (currentMinute == halfTimeMinute && secondInCurrentMinute == 0)
                HalfTime();
            else if (currentMinute == fullTimeMinute)
                FullTime();
            else
            {
                NextPlayerAction();
            }
        }

        private double CalculatePlayerActionSuccessProbability(PlayerAction playerAction)
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

        private void NextPlayerAction()
        {
            PlayerAction action = playerInPossesion.PlayerAI.TakeAction(squadInPossesion.Club.Tactic);
            double successProbability = CalculatePlayerActionSuccessProbability(action);
            double randomNum = r.NextDouble();
            Player playerToTakeTheBall;
            if (randomNum < successProbability)
            {
                // success
                switch (action.Type)
                {
                    case PlayerActionType.shoot:
                        matchView.UpdateMatchLog(CurrentTimeString, "\t\t" + playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ":" + playerInPossesion.Position + ")" + " scored a goal !!", "GOAL !!!");
                        score[squadInPossesion.Club.Id] += 1;
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
            matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ":" + playerInPossesion.Position + ")" +
                " passed ball to " + playerToTakeTheBall.Name + " (" + playerToTakeTheBall.Position + ")", "Pass");
            playerInPossesion = playerToTakeTheBall;
        }

        private void InterceptedTheBall(Player playerToTakeTheBall)
        {
            matchView.UpdateMatchLog(CurrentTimeString, playerToTakeTheBall.Name + " (" + squadOutOfPossesion.Club.ShortName + ":" + playerToTakeTheBall.Position + ")" +
                " intercepted ball from " + playerInPossesion.Name + " (" + playerInPossesion.Position + ")", "Interception");
            ChangePossesion();
            playerInPossesion = playerToTakeTheBall;
        }

        private void MakesASave(Player playerToMakeASave)
        {
            matchView.UpdateMatchLog(CurrentTimeString, "\t" + playerToMakeASave.Name + " (" + squadOutOfPossesion.Club.ShortName + ")" +
                " saves a shot from " + playerInPossesion.Name + " (" + playerInPossesion.Position + ") !", "Save");
            ChangePossesion();
            playerInPossesion = playerToMakeASave;
        }

        private void ChangePossesion()
        {
            MatchSquad temp = squadInPossesion;
            squadInPossesion = squadOutOfPossesion;
            squadOutOfPossesion = temp;
        }

        private void MatchKickOff()
        {
            score[homeSquad.Club.Id] = 0;
            score[awaySquad.Club.Id] = 0;

            double p = r.NextDouble();
            if (p >= 0.5)
            {
                squadInPossesion = homeSquad;
                squadOutOfPossesion = awaySquad;
            }
            else
            {
                squadInPossesion = awaySquad;
                squadOutOfPossesion = homeSquad;
            }
            squadThatStartedMatch = squadInPossesion;
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
            matchView.UpdateMatchLog(CurrentTimeString, "MATCH STARTS!", "Kickoff");
            kickOffTime = DateTime.Now;
            UpdateResultOnView();
        }

        private void GoalKickOff()
        {
            matchView.UpdateMatchLog(CurrentTimeString, "Match rasumes!", "Goal Kickoff");
            ChangePossesion();
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
            UpdateResultOnView();
        }

        private void HalfTime()
        {
            UpdateResultOnView();
            matchView.UpdateMatchLog(CurrentTimeString, "\n\nHALF TIME!", "Half Time");
            System.Diagnostics.Debug.WriteLine("Result = " + homeSquad.Club.ShortName + " " + score[homeSquad.Club.Id] + " : " + awaySquad.Club.ShortName + " " + score[awaySquad.Club.Id]);
            if (homeSquad.Club.Id == squadThatStartedMatch.Club.Id)
            {
                squadInPossesion = awaySquad;
                squadOutOfPossesion = homeSquad;
            }
            else
            {
                squadInPossesion = homeSquad;
                squadOutOfPossesion = awaySquad;
            }
            System.Diagnostics.Debug.WriteLine(squadInPossesion.Club.Name + " continues the game");
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
        }

        private void FullTime()
        {
            matchView.UpdateMatchLog(CurrentTimeString, "\n\nFINAL WHISTLE!", "Match End");
            System.Diagnostics.Debug.WriteLine("Result = " + homeSquad.Club.Name + " " + score[homeSquad.Club.Id] + " : " + awaySquad.Club.Name + " " + score[awaySquad.Club.Id]);
            SaveMatchResult();
        }

        private void SaveMatchResult()
        {
            int homeGoals = score[homeSquad.Club.Id];
            int awayGoals = score[awaySquad.Club.Id];
            MatchResult matchResult = new MatchResult(homeSquad.Club, awaySquad.Club, homeGoals, awayGoals, kickOffTime);
            _resultRepository.addMatchResult(matchResult);
        }

        private void UpdateResultOnView()
        {
            int homeGoals = score[homeSquad.Club.Id];
            int awayGoals = score[awaySquad.Club.Id];
            matchView.UpdateResult(homeGoals, awayGoals);
        }
    }
}