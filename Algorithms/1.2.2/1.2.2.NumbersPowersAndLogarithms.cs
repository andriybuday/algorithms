using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms._1._2._2
{
    public static class LogarithmCalculation
    {
        public static double Log10From2()
        {
            double result = 0;

            double b = 0;
            double x = 2.0;
            double twoMultiplier = 2;
            for(int k = 0; k < 10000; ++k)
            {
                var x2 = x * x;
                if (x2 < 10)
                {
                    x = x2;
                    b = 0;
                }
                else
                {
                    x = x2 / 10.0;
                    b = 1;
                }
                result += b / twoMultiplier;
                twoMultiplier *= 2.0;
            }

            return result;
        }
    }
}
