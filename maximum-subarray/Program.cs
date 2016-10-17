// BEGIN CUT HERE

// END CUT HERE
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Diagnostics;
using System.Linq;

public class MaximumSubarrayCLRS
{
    public Tuple<int, int, int> divideAndConquer(int[] input) {
        if(input.Length <= 1) throw new Exception("wrong input");        
        var result = divideAndConquer(input, 0, input.Length - 1);
        return (result.Item3 < 0) ? result : new Tuple<int, int, int> (-1, -1, -1);
    }

    public Tuple<int, int, int> maxSubarrayNaive(int[] input) {
        if(input.Length <= 1) throw new Exception("wrong input");
        var result = maxSubarrayNaive(input, 0, input.Length - 1);
        return (result.Item3 < 0) ? result : new Tuple<int, int, int> (-1, -1, -1);
    }

    private Tuple<int, int, int> maxCrossingTheMiddle(int[] input, int a, int b, int m) {
        int maxLeft = int.MinValue, maxRight = int.MinValue;
        int start = 0, end = 0, sum = 0;
        for(int i = m; i >= a; --i){
            sum += input[i];
            if(sum > maxLeft) {
                maxLeft = sum;
                start = i;
            }
        }
        sum = 0;
        for(int i = m + 1; i <= b; ++i) {
            sum += input[i];
            if(sum > maxRight) {
                maxRight = sum;
                end = i;
            }
        }
        return new Tuple<int, int, int> (start, end, maxLeft + maxRight);
    }
    private Tuple<int, int, int> divideAndConquer(int[] input, int a, int b) {
        int n = b - a;
        int m = a + n / 2;

        if(n == 0) {
            return new Tuple<int, int, int> (a, b, input[a]);
        }

        var leftResult = divideAndConquer(input, a, m);
        var rightResult = divideAndConquer(input, m + 1, b);
        var currentMax = Math.Max(leftResult.Item3, rightResult.Item3);
        
        // TODO: replace with correct impl
        var naiveAtoB = maxCrossingTheMiddle(input, a, b, m);

        if(leftResult.Item3 > rightResult.Item3) {
            if(leftResult.Item3 > naiveAtoB.Item3) {
                return leftResult;
            } else {
                return naiveAtoB;
            }
        } else if(rightResult.Item3 > naiveAtoB.Item3) {
            return rightResult;
        } else {
            return naiveAtoB;
        }
    }

    private Tuple<int, int, int> maxSubarrayNaive(int[] input, int a, int b) {
        int N = b - a;
        int start = 0;
        int end = 0;

        int maxSum = int.MinValue;

        for(int i = a; i <= b; i++){
            for(int j = a; j <= b; j++){
                int sum = 0;
                for(int k = i; k <= j; k++){
                    sum += input[k];
                }
                if(sum > maxSum){
                    maxSum = sum;
                    start = i;
                    end = j;
                }
            }    
        }

        if(maxSum < 0){
            return new Tuple<int, int, int> (0, 0, 0); 
        }

        return new Tuple<int, int, int> (start, end, maxSum);
    }

    public int[] PreprocessPriceChangeArray(int[] input) {
        if(input.Length <= 1) {
            throw new Exception("wrong input");
        }
        int N = input.Length;
        int [] changeArray = new int[N];
        changeArray[0] = 0;

        for(int i = 1; i < N; i++) {
            changeArray[i] = input[i] - input[i -1];  
        }
        return changeArray;
    }

    public static int[] GenerateInputArray(int N){
        int[] a = new int[N];
        for(int i = 0; i < N; ++i) {
            a[i] = new Random().Next(-5000, 5000);
        }
        return a;
    }

    // BEGIN CUT HERE
    public static void Main(String[] args)
    {
        try
        {
            //    var sw = new Stopwatch();
            //    sw.Start();
            //    some stuff
            //    sw.Stop();

            // simple test
            eq(0, (new MaximumSubarrayCLRS())
                .divideAndConquer(new int[] {-1, 4, 5, -3}),
                new Tuple<int, int, int>(1, 2, 9));
            var input = new int[] {-1, 4, -1, 5, -3, -3, 6};
            var naiveResult = (new MaximumSubarrayCLRS()).maxSubarrayNaive(input);
            var divideResult = (new MaximumSubarrayCLRS()).divideAndConquer(input);
            eq(1, naiveResult.Item3, divideResult.Item3);
            eq(2, naiveResult, divideResult);

            input = GenerateInputArray(2000);
            var sw = new Stopwatch();
            sw.Start();
            naiveResult = (new MaximumSubarrayCLRS()).maxSubarrayNaive(input);
            sw.Stop();
            Console.WriteLine($"Naive time: {sw.Elapsed}");
            sw.Reset();
            sw.Start();
            divideResult = (new MaximumSubarrayCLRS()).divideAndConquer(input);
            sw.Stop();
            Console.WriteLine($"Divide time: {sw.Elapsed}");
            eq(1, naiveResult.Item3, divideResult.Item3);
            eq(2, naiveResult, divideResult);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
            System.Console.WriteLine(ex.StackTrace);
        }
    }
    private static void eq(int n, object have, object need)
    {
        if (eq(have, need))
        {
            Console.WriteLine("Case " + n + " passed.");
        }
        else
        {
            Console.Write("Case " + n + " failed: expected ");
            print(need);
            Console.Write(", received ");
            print(have);
            Console.WriteLine();
        }
    }
    private static void eq(int n, Array have, Array need)
    {
        if (have == null || have.Length != need.Length)
        {
            Console.WriteLine("Case " + n + " failed: returned " + have.Length + " elements; expected " + need.Length + " elements.");
            print(have);
            print(need);
            return;
        }
        for (int i = 0; i < have.Length; i++)
        {
            if (!eq(have.GetValue(i), need.GetValue(i)))
            {
                Console.WriteLine("Case " + n + " failed. Expected and returned array differ in position " + i);
                print(have);
                print(need);
                return;
            }
        }
        Console.WriteLine("Case " + n + " passed.");
    }
    private static bool eq(object a, object b)
    {
        if (a is double && b is double)
        {
            return Math.Abs((double)a - (double)b) < 1E-9;
        }
        else
        {
            return a != null && b != null && a.Equals(b);
        }
    }
    private static void print(object a)
    {
        if (a is string)
        {
            Console.Write("\"{0}\"", a);
        }
        else if (a is long)
        {
            Console.Write("{0}L", a);
        }
        else
        {
            Console.Write(a);
        }
    }
    private static void print(Array a)
    {
        if (a == null)
        {
            Console.WriteLine("<NULL>");
        }
        Console.Write('{');
        for (int i = 0; i < a.Length; i++)
        {
            print(a.GetValue(i));
            if (i != a.Length - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine('}');
    }
    // END CUT HERE
}
