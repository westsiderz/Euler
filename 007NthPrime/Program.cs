using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _007NthPrime
{
    class Program
    {
        const int MAX_N = 10001;
        static long[] allPrimes = new long[MAX_N];

        static bool IsPrime(int numb, int index)
        {
            for (int i = 0; i < index; i++)
            {
                if (numb % allPrimes[i] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void FindAllPrimes()
        {
            allPrimes[0] = 2;
            int i = 0, currPrime = 3;

            while (i < MAX_N - 1)
            {
                if (IsPrime(currPrime, i + 1))
                {
                    allPrimes[i + 1] = currPrime;
                    i++;
                }
                currPrime += 2;
            }
        }

        static void TestIt()
        {
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(allPrimes[index - 1]);
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            FindAllPrimes();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
