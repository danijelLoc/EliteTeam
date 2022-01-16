using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EliteTeam.Model
{
    public class MathHelper
    {
        public static Random r = new Random();
        public static int keepInRange(int inputValue, int min, int max)
        {
            return inputValue >= max ? max : (inputValue <= min ? min : inputValue);
        }
    }
}