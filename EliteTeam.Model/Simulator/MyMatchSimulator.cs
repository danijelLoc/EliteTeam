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
        private Club clubThatMadeMatchKickOff;

        private Player playerInPossesion;
        private Club clubInPossesion;
        private Club clubOutOfPossesion;

        Dictionary<string, int> score = new Dictionary<string, int>();

        public void Simulate(Club homeClub, Club awayClub)
        {
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
            double oppositionGoalkeeping = 1.0 * clubOutOfPossesion.ClubSquad.GoalKeeper.Stats.Shooting / Stats.MaxValue;
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
                    oppositionMidDefBallRecovery += clubOutOfPossesion.ClubSquad.Defence.Sum(x => x.Stats.Interceptions);
                    oppositionMidDefBallRecovery += clubOutOfPossesion.ClubSquad.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidDefBallRecovery = oppositionMidDefBallRecovery / ((clubOutOfPossesion.ClubSquad.Defence.Count + clubOutOfPossesion.ClubSquad.Midfield.Count) * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidDefBallRecovery);
                    successProbability *= 1.2; // interceptions are not that frequent, passing made more accurate
                    break;
                case PlayerActionType.passToMidfield:
                    double oppositionMidfieldBallRecovery = 0.001;
                    oppositionMidfieldBallRecovery += clubOutOfPossesion.ClubSquad.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidfieldBallRecovery = oppositionMidfieldBallRecovery / (clubOutOfPossesion.ClubSquad.Midfield.Count * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidfieldBallRecovery);
                    successProbability *= 1.3;
                    break;
                case PlayerActionType.passToDefence:
                    double oppositionMidAttBallRecovery = 0.001;
                    oppositionMidAttBallRecovery += clubOutOfPossesion.ClubSquad.Attack.Sum(x => x.Stats.Interceptions);
                    oppositionMidAttBallRecovery += clubOutOfPossesion.ClubSquad.Midfield.Sum(x => x.Stats.Interceptions);
                    oppositionMidAttBallRecovery = oppositionMidAttBallRecovery / ((clubOutOfPossesion.ClubSquad.Attack.Count + clubOutOfPossesion.ClubSquad.Midfield.Count) * Stats.MaxValue);
                    successProbability = passing / (passing + oppositionMidAttBallRecovery);
                    successProbability *= 1.5;
                    break;
                case PlayerActionType.passToGoalkeeper:
                    double oppositionAttackBallRecovery = 0.001;
                    oppositionAttackBallRecovery += clubOutOfPossesion.ClubSquad.Attack.Sum(x => x.Stats.Interceptions);
                    oppositionAttackBallRecovery = oppositionAttackBallRecovery / (clubOutOfPossesion.ClubSquad.Attack.Count * Stats.MaxValue);
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
                        playerToTakeTheBall = clubInPossesion.ClubSquad.Attack[r.Next(clubInPossesion.ClubSquad.Attack.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToMidfield:
                        playerToTakeTheBall = clubInPossesion.ClubSquad.Midfield[r.Next(clubInPossesion.ClubSquad.Midfield.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToDefence:
                        playerToTakeTheBall = clubInPossesion.ClubSquad.Defence[r.Next(clubInPossesion.ClubSquad.Defence.Count)];
                        PassedTheBall(playerToTakeTheBall);
                        break;
                    case PlayerActionType.passToGoalkeeper:
                        PassedTheBall(clubInPossesion.ClubSquad.GoalKeeper);
                        break;
                }
            }
            else
            {
                // failure
                switch (action.OpositionReactionType)
                {
                    case PossibleReactionType.oppositionGoalKeeperMakesASave:
                        MakesASave(clubOutOfPossesion.ClubSquad.GoalKeeper);
                        break;
                    case PossibleReactionType.oppositionDefenceTakesTheBall:
                        playerToTakeTheBall = clubOutOfPossesion.ClubSquad.Defence[r.Next(clubOutOfPossesion.ClubSquad.Defence.Count)];
                        InterceptedTheBall(playerToTakeTheBall);
                        break;
                    case PossibleReactionType.oppositionMidfieldTakesTheBall:
                        playerToTakeTheBall = clubOutOfPossesion.ClubSquad.Midfield[r.Next(clubOutOfPossesion.ClubSquad.Midfield.Count)];
                        InterceptedTheBall(playerToTakeTheBall);
                        break;
                    case PossibleReactionType.oppositionAttackTakesTheBall:
                        playerToTakeTheBall = clubOutOfPossesion.ClubSquad.Attack[r.Next(clubOutOfPossesion.ClubSquad.Attack.Count)];
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
            Club temp = clubInPossesion;
            clubInPossesion = clubOutOfPossesion;
            clubOutOfPossesion = temp;
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
                clubOutOfPossesion = awayClub;
            }
            else
            {
                clubInPossesion = awayClub;
                clubOutOfPossesion = homeClub;
            }
            clubThatMadeMatchKickOff = clubInPossesion;
            System.Diagnostics.Debug.WriteLine(clubInPossesion.Name + " starts the game.");
            playerInPossesion = clubInPossesion.ClubSquad.Midfield[r.Next(clubInPossesion.ClubSquad.Midfield.Count)];
        }

        public void GoalKickOff()
        {
            System.Diagnostics.Debug.WriteLine("Match rasumes!");
            ChangePossesion();
            playerInPossesion = clubInPossesion.ClubSquad.Midfield[r.Next(clubInPossesion.ClubSquad.Midfield.Count)];
        }

        public void HalfTime()
        {
            System.Diagnostics.Debug.WriteLine("\n\nHALF TIME!");
            System.Diagnostics.Debug.WriteLine("Result = " + homeClub.ShortName + " " + score[homeClub.Id] + " : " + awayClub.ShortName + " " + score[awayClub.Id]);
            System.Diagnostics.Debug.WriteLine("Match rasumes!\n\n");
            if (homeClub.Id == clubThatMadeMatchKickOff.Id)
            {
                clubInPossesion = awayClub;
            }
            else
            {
                clubInPossesion = homeClub;
            }
            System.Diagnostics.Debug.WriteLine(clubInPossesion.Name + " continues the game");
            playerInPossesion = clubInPossesion.ClubSquad.Midfield[r.Next(clubInPossesion.ClubSquad.Midfield.Count)];
        }

        public void FullTime()
        {
            System.Diagnostics.Debug.WriteLine("\n\nFINAL WHISTLE!");
            System.Diagnostics.Debug.WriteLine("MATCH IS FINSHED!");
            System.Diagnostics.Debug.WriteLine("Result = " + homeClub.Name + " " + score[homeClub.Id] + " : " + awayClub.Name + " " + score[awayClub.Id]);
        }
    }
}