using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _010SummationPrimes
{
    class Program
    {
        const int MAX_ELEMENT = 1000000;
        static int[] allPrimes = new int[MAX_ELEMENT];
        static long[] allResults = new long[MAX_ELEMENT];

        static void GenerateAllPrimes()
        {
            long res = 0;
            for (int i = 2; i <= MAX_ELEMENT; i++)
            {
                allPrimes[i-2] = i;
            }

            for (int i = 0; i < MAX_ELEMENT; i++)
            {
                int num = allPrimes[i];
                if(num == 0)
                {
                    continue;
                }
                int j = i + num;
                while (j < MAX_ELEMENT)
                {
                    
                    allPrimes[j] = 0;
                    j += num;
                    
                }
            }
            for (int i = 0; i < MAX_ELEMENT - 1; i++)
            {
                res += allPrimes[i];
                allResults[i] = res;
            }
        }

        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            if (n < 2)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(allResults[n - 2]);
            }
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            GenerateAllPrimes();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
