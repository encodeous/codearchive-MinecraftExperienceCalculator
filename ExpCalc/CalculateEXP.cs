using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;

namespace ExpCalc
{
    class CalculateExp
    {
        public static BigInteger LinearFunctionSum(BigInteger a, BigInteger b, BigInteger m, BigInteger n)
        {
            // Sum of a linear function in o(1) time
            // https://math.stackexchange.com/questions/296476/formula-for-calculating-the-sum-of-a-series-of-function-results-over-a-specific#:~:text=The%20sum%20of%20ax,cx%2C%20and%20so%20on.
            return a * (((n + m) * (n - m + 1)) / 2) + b * (n - m + 1);
        }
        public static BigInteger GetExperienceFromLevel(BigInteger level)
        {
            if (level == 0) return 0;
            level--;
            BigInteger sum = 0;
            if (level > 30)
            {
                sum += LinearFunctionSum(9, -158, 31, level);
                level = 30;
            }
            if (level > 15)
            {
                sum += LinearFunctionSum(5, -38, 16, level);
                level = 15;
            }
            if (level > 0)
            {
                sum += LinearFunctionSum(2, 7, 1, level);
            }
            return sum + 7;
        }
        public static BigInteger GetLevelFromExperience(BigInteger exp)
        {
            BigInteger low = 0;
            BigInteger high = exp;
            while (low < high)
            {
                BigInteger mid = low + (high - low) / 2;
                if (GetExperienceFromLevel(mid) >= exp)
                {
                    high = mid;
                }
                else
                {
                    low = mid + 1;
                }
            }
            if (GetExperienceFromLevel(low) > exp) low--;
            return low;
        }
        public static BigInteger getExpUntilNextLevel(BigInteger exp, BigInteger NextLevel)
        {
            return GetExperienceFromLevel(NextLevel) - exp;
        }
    }
}
