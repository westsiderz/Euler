using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _006SumSquareDiff
{
    class Program
    {
        static void TestIt()
        {
            long n = Convert.ToInt32(Console.ReadLine());
            long sumSquare = (n * (n + 1)) / 2;
            sumSquare = (long)Math.Pow(sumSquare, 2);

            long squaresSum = (n * (n + 1) * (2 * n + 1)) / 6;
            Console.WriteLine(sumSquare - squaresSum);

        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
