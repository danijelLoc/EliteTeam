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
        private bool _started = false;
        private Random r = MathHelper.r;
        private IMatchView matchView;
        private IMatchController _matchController;
        private MatchSquad homeSquad;
        private MatchSquad awaySquad;
        private MatchSquad squadInPossesion;
        private MatchSquad squadOutOfPossesion;
        private MatchSquad squadThatStartedMatch;
        private Player playerInPossesion;

        private DateTime kickOffTime;
        private Dictionary<string, int> score = null;

        public readonly int halfTimeMinute = 45;
        public readonly int fullTimeMinute = 90;
        private int matchTimeMinutes;
        private int matchTimeSeconds;
        private string CurrentTimeString
        {
            get
            {
                var minute = matchTimeMinutes < 10 ? "0" + matchTimeMinutes.ToString() : matchTimeMinutes.ToString();
                var second = matchTimeSeconds < 10 ? "0" + matchTimeSeconds.ToString() : matchTimeSeconds.ToString();
                return minute + ":" + second;
            }
        }
        public bool MatchHasStarted { get { return _started; } }


        public MatchSimulationController(IMatchController matchController)
        {
            _matchController = matchController;
        }

        public void CreateSimulation(IMatchView matchView, MatchSquad homeSquad, MatchSquad awaySquad)
        {
            score = new Dictionary<string, int>();
            this.homeSquad = homeSquad;
            this.awaySquad = awaySquad;
            this.matchView = matchView;
        }

        public void NextAction(IMatchView matchView)
        {
            if (matchTimeMinutes == 0 && matchTimeSeconds == 0)
                MatchKickOff();
            else if (matchTimeMinutes == halfTimeMinute && matchTimeSeconds == 0)
                HalfTime();
            else if (matchTimeMinutes >= fullTimeMinute)
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
                        ScoreAGoal(playerInPossesion);
                        return;
                    case PlayerActionType.passToAttack:
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
            // action takes time
            AddTime(1, 0);
        }

        private void ScoreAGoal(Player playerToScore)
        {
            score[squadInPossesion.Club.Id] += 1;
            matchView.UpdateMatchLog(CurrentTimeString, playerToScore.Name + " (" + squadInPossesion.Club.ShortName + ":" + playerToScore.Position + ")" + " scored a goal !!!", "GOAL !!!");
            GoalKickOff();
        }

        private void PassedTheBall(Player playerToTakeTheBall)
        {
            if (playerInPossesion.Id == playerToTakeTheBall.Id)
            {
                matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ":" + playerInPossesion.Position + ")" +
                " dribbles the ball.", "Dribble");
                // TODO add real dribbling and prevent pass to yourself
            }
            else
            {
                matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ":" + playerInPossesion.Position + ")" +
                    " passed ball to " + playerToTakeTheBall.Name + " (" + playerToTakeTheBall.Position + ")", "Pass");
                playerInPossesion = playerToTakeTheBall;
            }
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
            matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ") " + "starts the game !", "Kickoff");
            kickOffTime = DateTime.Now;
            _started = true;
            NextPlayerAction();
            UpdateResultOnView();
        }

        private void GoalKickOff()
        {
            UpdateResultOnView();
            // goal kicoff takes time
            AddTime(1, 0);
            // maybe time is up after stopage time addition
            if (matchTimeMinutes == 90)
                return;
            ChangePossesion();
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
            matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ") " + "resumes the game.", "Goal Kickoff");
            NextAction(matchView);
        }

        private void HalfTime()
        {
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
            playerInPossesion = squadInPossesion.Midfield[r.Next(squadInPossesion.Midfield.Count)];
            matchView.UpdateMatchLog(CurrentTimeString, playerInPossesion.Name + " (" + squadInPossesion.Club.ShortName + ") " + "starts the second half !", "Half Time");
            NextPlayerAction();
            //matchView.Pause();
        }

        private void FullTime()
        {
            matchView.UpdateMatchLog(CurrentTimeString, "\n\nFINAL WHISTLE !", "Match End");
            matchView.Stop();
            SaveMatchResult();
        }

        private void AddTime(int minutes, int seconds)
        {
            matchTimeMinutes += minutes;
            matchTimeSeconds += seconds;

            matchTimeMinutes += matchTimeSeconds / 60;
            matchTimeSeconds %= 60;

            if (matchTimeMinutes > 90)
                return;

            matchView.UpdateTime(matchTimeMinutes, matchTimeSeconds);
        }

        private void SaveMatchResult()
        {
            try
            {
                int homeGoals = score[homeSquad.Club.Id];
                int awayGoals = score[awaySquad.Club.Id];
                MatchResult matchResult = new MatchResult(homeSquad.Club, awaySquad.Club, homeGoals, awayGoals, kickOffTime);
                _matchController.AddMatchResult(matchView, matchResult);
            }
            catch (Exception exc)
            {
                matchView.ShowMessage(exc.Message);
            }
        }

        private void UpdateResultOnView()
        {
            int homeGoals = score[homeSquad.Club.Id];
            int awayGoals = score[awaySquad.Club.Id];
            matchView.UpdateResult(homeGoals, awayGoals);
        }
    }
}