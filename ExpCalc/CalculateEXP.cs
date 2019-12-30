using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ExpCalc
{
    class CalculateEXP
    {
        public static BigInteger getExpAtLevel(BigInteger level)
        {
            if (level <= 15)
            {
                return (2 * level) + 7;
            }
            if ((level >= 16) && (level <= 30))
            {
                return (5 * level) - 38;
            }
            return (9 * level) - 158;
        }

        public static BigInteger getExpToLevel(BigInteger level)
        {
            BigInteger currentLevel = 0;
            BigInteger exp = 0;

            while (currentLevel < level)
            {
                exp = exp + getExpAtLevel(currentLevel);
                currentLevel++;
            }
            if (exp < 0)
            {
                exp = int.MaxValue;
            }
            return exp;
        }
        public static BigInteger getTotalLevels(BigInteger exp, out BigInteger remainder)
        {
            BigInteger timesLooped = 0;
            BigInteger currentExp = exp;
            BigInteger Level = 0;
            BigInteger PrevExp = 0;
            while (exp >= 0)
            {
                PrevExp = exp;
                exp -= getExpAtLevel(Level);
                Level++;
            }
            remainder = getExpAtLevel(Level) - PrevExp;
            return Level-1;
        }

        public static BigInteger getTotalExperience(BigInteger level)
        {
            BigInteger exp = (getExpAtLevel(level) * (BigInteger)getExpPercentNeeded(level));
            BigInteger currentLevel = level;
            while (currentLevel > 0)
            {
                currentLevel--;
                exp += getExpAtLevel(currentLevel);
            }
            if (exp < 0)
            {
                exp = int.MaxValue;
            }
            return exp;
        }
        
        public static BigInteger getExpUntilNextLevel(BigInteger exp, BigInteger NextLevel)
        {
            return getTotalExperience(NextLevel) - exp;
        }
        
        public static double getExpPercentNeeded(BigInteger level)
        {
            BigInteger temp = getExpAtLevel(level+1);
            return (double)getExpAtLevel(level) / (double)temp;
        }
    }
}
