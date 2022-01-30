using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class Stats
    {
        public static readonly int MinValue = 1;
        public static readonly int MaxValue = 5;

        private int _shooting;
        private int _passing;
        private int _dribling;
        private int _speed;
        private int _stamina;
        private int _strenght;
        private int _interceptions;
        private int _goalkeeping;

        public int Shooting { get { return _shooting; } set { _shooting = MathHelper.keepInRange(value, MinValue, MaxValue); } }
        public int Passing { get { return _passing; } set { _passing = MathHelper.keepInRange(value, MinValue, MaxValue); } }
        public int Dribling { get { return _dribling; } set { _dribling = MathHelper.keepInRange(value, MinValue, MaxValue); } }

        public int Speed { get { return _speed; } set { _speed = MathHelper.keepInRange(value, MinValue, MaxValue); } }
        public int Stamina { get { return _stamina; } set { _stamina = MathHelper.keepInRange(value, MinValue, MaxValue); } }
        public int Strenght { get { return _strenght; } set { _strenght = MathHelper.keepInRange(value, MinValue, MaxValue); } }
        public int Interceptions { get { return _interceptions; } set { _interceptions = MathHelper.keepInRange(value, MinValue, MaxValue); } }

        public int Goalkeeping { get { return _goalkeeping; } set { _goalkeeping = MathHelper.keepInRange(value, MinValue, MaxValue); } }

        public Stats(int shooting, int speed, int stamina, int strenght, int passing, int interceptions, int dribling, int goalkeeping)
        {
            Shooting = shooting;
            Speed = speed;
            Stamina = stamina;
            Strenght = strenght;
            Passing = passing;
            Interceptions = interceptions;
            Dribling = dribling;
            Goalkeeping = goalkeeping;
        }
        public Stats()
        {
            Shooting = MinValue;
            Speed = MinValue;
            Stamina = MinValue;
            Strenght = MinValue;
            Passing = MinValue;
            Interceptions = MinValue;
            Dribling = MinValue;
            Goalkeeping = MinValue;
        }
        public Stats(Stats otherStats)
        {
            Shooting = otherStats.Shooting;
            Speed = otherStats.Speed;
            Stamina = otherStats.Stamina;
            Strenght = otherStats.Strenght;
            Passing = otherStats.Passing;
            Interceptions = otherStats.Interceptions;
            Dribling = otherStats.Dribling;
            Goalkeeping = otherStats.Goalkeeping;
        }
    }
}