using System;

namespace Algorithms
{
    public static class Algorithms
    {
        public static int Gcd(int m, int n)
        {
            if (m <= 0 || n <= 0)
                throw new ArgumentException("Parameters must be positive integers");

            return GcdIterative(m, n);
        }
        private static int GcdIterative(int m, int n)
        {
            int tmp;
            while (n != 0)
            {
                tmp = n;
                n = m % n;
                m = tmp;
            }
            return m;
        }
        private static int GcdRecursive(int m, int n)
        {
            return (n != 0) ? GcdRecursive(n, m % n) : m;
        }

        public static int[] ExtendedEuclid(int m, int n)
        {
            if (m <= 0 || n <= 0)
                throw new ArgumentException("Parameters must be positive integers");

            return ExtendedEuclidAsInTAoCP(m, n);
        }
        private static int[] ExtendedEuclidAsInTAoCP(int m, int n)
        {
            int a = 0, b = 1, a1 = 1, c = m, b1 = 0, d = n, r = 0, q = 0, t = 0;

            q = c / d;
            r = c % d;
            while (r != 0)
            {
                c = d; d = r;
                t = a1; a1 = a; a = t - q * a;
                t = b1; b1 = b; b = t - q * b;

                q = c / d;
                r = c % d;
            }

            return new int[] { a, b, d };
        }
        private static int[] ExtendedEuclid_LessVariables(int m, int n)
        {
            int a = 0, b = 1, a1 = 1, b1 = 0, r = 0, q = 0, tmp = 0;

            while (n != 0)
            {
                tmp = a1; a1 = a; a = tmp - q * a;
                tmp = b1; b1 = b; b = tmp - q * b;

                q = m / n;
                r = m % n;

                m = n; n = r;
            }

            return new int[] { b, a, m };
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            //Console.WriteLine(Algorithms.Gcd(12, 8));
            //Console.WriteLine(Algorithms.Gcd(8, 12));
            //var n = 551;
            //var m = 1769;
            //Console.WriteLine(Algorithms.Gcd(m, n));
            //Console.WriteLine(Algorithms.Gcd(n, m));
            //var e = Algorithms.ExtendedEuclid(m, n);
            //Console.WriteLine(string.Format("{0}*{1} + {2}*{3} = {4}", e[0], m, e[1], n, e[2]));
            new InsertionSortTests().Run();
        }
    }


    public class InsertionSortTests
    {
        public void Run()
        {
            var a = new int[] { 5, 2, 4, 6, 1, 3 };
            InsertionSort.Sort(a);
            var expected = new int[] { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != expected[i])
                {
                    throw new Exception("Basic insertion sort test fail.");
                }
            }
        }
    }
}
