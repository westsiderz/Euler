using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

/*
 * C = (m + 1)! / m! * n!
 */

namespace _015LatticePaths
{
    class Program
    {
        const int MAX_COUNT = 500;
        static BigInteger[,] allResults = new BigInteger[MAX_COUNT, MAX_COUNT];
        static BigInteger[] allFacts = new BigInteger[(2 * MAX_COUNT) + 1];

        static void PrecomputeAllFacts()
        {
            allFacts[0] = 1;
            for (int i = 1; i <= 2 * MAX_COUNT; i++)
            {
                allFacts[i] = allFacts[i - 1] * i;
            }
        }

        static void TestIt()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(input[0]);
            int m = Convert.ToInt32(input[1]);
            Console.WriteLine(((allFacts[m + n]) / (allFacts[m] * allFacts[n]) % (1000000000 + 7)));

        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            PrecomputeAllFacts();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
