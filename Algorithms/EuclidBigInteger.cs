using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    public static class EuclidBigInteger
    {
        public static string GcdBigInteger(string n, string m)
        {
            return GcdBigInteger(BigInteger.Parse(n), BigInteger.Parse(m)).ToString();
        }

        private static BigInteger GcdBigInteger(BigInteger n, BigInteger m)
        {
            while (!m.IsZero)
            {
                var r = n % m;
                n = m;
                m = r;
            }
            return n;
        }
    }
}
