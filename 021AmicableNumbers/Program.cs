using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _021AmicableNumbers
{
    class Program
    {
        const int MAX_NUMBERS=100000;
        static bool[] isChecked = new bool[MAX_NUMBERS];
        static bool[] isAmicable = new bool[MAX_NUMBERS];
        static int[] allPrimes = new int[MAX_NUMBERS];
        static long[] amicableSums = new long[MAX_NUMBERS];

        static void RemoveThePrimes()
        {
            for (int i = 2; i <= MAX_NUMBERS; i++)
            {
                allPrimes[i - 2] = i;
            }

            for (int i = 0; i < MAX_NUMBERS; i++)
            {
                int num = allPrimes[i];
                if (num == 0)
                {
                    continue;
                }
                int j = i + num;
                while (j < MAX_NUMBERS)
                {

                    allPrimes[j] = 0;
                    j += num;

                }
            }

            for (int i = 0; i < MAX_NUMBERS; i++)
            {
                if (allPrimes[i] != 0)
                {
                    isChecked[i] = true;
                }
            }
        }

        static int MultiplesSum(int number)
        {
            int sum = 1;
            int res = 0;

            for (int i = 2; i < Math.Sqrt(number); i++)
            {
                res = number % i;
                if (res == 0)
                {
                    res = number / i;
                    sum += i;
                    if (res != i)
                    {
                        sum += res;
                    }  
                }
            }

            return sum;
        }

        static void FindAllAmicable()
        {
            for (int i = 0; i < MAX_NUMBERS; i++)
            {
                if (isChecked[i] == true)
                {
                    continue;
                }

                int numb = i + 2;

                int tempRes1 = MultiplesSum(numb);

                if (tempRes1 == numb)
                {
                    isChecked[i] = true;
                    continue;
                }

                int tempRes2 = MultiplesSum(tempRes1);

                if (tempRes2 == numb)
                {
                    isAmicable[i] = true;
                    isChecked[i] = true;
                    isAmicable[tempRes1 - 2] = true;
                    isChecked[tempRes1 - 2] = true;
                }

            }
        }

        static void FindAllSums()
        {
            long tempSum = 0;
            for (int i = 0; i < MAX_NUMBERS; i++)
            {
                if (isAmicable[i] == true)
                {
                    tempSum += i + 2;
                }
                amicableSums[i] = tempSum;
            }
        }

        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            if (n <= 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(amicableSums[n - 2]);
            }
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            RemoveThePrimes();
            FindAllAmicable();
            FindAllSums();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
