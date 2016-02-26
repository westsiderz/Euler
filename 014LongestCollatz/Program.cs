using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _014LongestCollatz
{
    class Program
    {
        const int MAX_VALUE = 5000000;
        static int[] allLengths = new int[MAX_VALUE];
        static int[] allLongest = new int[MAX_VALUE];

        static void FindLengthOfNumber(int number)
        {
            int count = 1;
            long tempNumb = (long)number;
            while (tempNumb != 1)
            {
                if (tempNumb % 2 == 0)
                {
                    tempNumb /= 2;
                }
                else
                {
                    tempNumb = (3 * tempNumb + 1);
                }

                if ((tempNumb < MAX_VALUE) && (allLengths[tempNumb - 1] != 0))
                {
                    allLengths[number - 1] = count + allLengths[tempNumb - 1];
                    return;
                }
                else
                {
                    count++;
                }
            }
            allLengths[number - 1] = count;
        }
        static void GenerateSequences()
        {
            allLengths[0] = 1;
            allLongest[0] = 1;
            int max = 0;
            for(int i = 2; i <= MAX_VALUE; i++)
            {
                FindLengthOfNumber(i);
            }
            for (int i = 1; i < MAX_VALUE; i++)
            {
                if (allLengths[max] <= allLengths[i])
                {
                    max = i;
                    allLongest[i] = i;
                }
                else
                {
                    allLongest[i] = max;
                }
            }
        }
        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine(allLongest[n - 1] + 1);
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            GenerateSequences();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
