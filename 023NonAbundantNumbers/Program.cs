using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _023NonAbundantNumbers
{
    class Program
    {
        const int MAX_BORDER = 28123;
        static bool[] isChecked = new bool[MAX_BORDER];
        static bool[] isAbundant = new bool[MAX_BORDER];
        static int[] allPrimes = new int[MAX_BORDER];

        static void RemoveThePrimes()
        {
            for (int i = 2; i <= MAX_BORDER; i++)
            {
                allPrimes[i - 2] = i;
            }

            for (int i = 0; i < MAX_BORDER; i++)
            {
                int num = allPrimes[i];
                if (num == 0)
                {
                    continue;
                }
                int j = i + num;
                while (j < MAX_BORDER)
                {

                    allPrimes[j] = 0;
                    j += num;

                }
            }

            for (int i = 0; i < MAX_BORDER; i++)
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

        static void FindAllAbundant()
        {
            for (int i = 0; i < MAX_BORDER; i++)
            {
                if (isChecked[i] == true)
                {
                    continue;
                }

                int numb = i + 2;

                int tempRes1 = MultiplesSum(numb);

                if (tempRes1 > numb)
                {
                    isChecked[i] = true;
                    isAbundant[i] = true;
                }
            }
        }

        static bool isSumOfAbundants(int numb)
        {
            for (int i = 10; i <= numb / 2; i++)
            {
                if (isAbundant[i] == false)
                {
                    continue;
                }

                int tempRes = numb - (i + 2);
                if (isAbundant[tempRes - 2])
                {
                    return true;
                }
            }

            return false;
        }

        static void TestIt()
        {
            int numb = Convert.ToInt32(Console.ReadLine());

            if (numb < 24)
            {
                Console.WriteLine("NO");

            }
            else if (numb > MAX_BORDER)
            {
                Console.WriteLine("YES");
            }
            else
            {
                if (isSumOfAbundants(numb))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    Console.WriteLine("NO");
                }
            }
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            RemoveThePrimes();
            FindAllAbundant();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
