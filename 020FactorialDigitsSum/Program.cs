using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _020FactorialDigitsSum
{
    class Program
    {
        const int MAX_COUNT = 1001;
        static BigInteger[] allFacts = new BigInteger[MAX_COUNT];

        static void PrecomputeAllFacts()
        {
            allFacts[0] = 1;
            for (int i = 1; i < MAX_COUNT; i++)
            {
                allFacts[i] = allFacts[i - 1] * i;
            }
        }

        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger number = allFacts[n];
            BigInteger result = new BigInteger(0);

            while (number > 0)
            {
                result += number % 10;
                number /= 10;
            }

            Console.WriteLine(result);
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
