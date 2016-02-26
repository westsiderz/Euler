using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _008LargestProductInSeries
{
    class Program
    {
        static void TestIt()
        {
            string[] input = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(input[0]);
            int k = Convert.ToInt32(input[1]);
            string number = Console.ReadLine();

            int[] results = new int[n - k + 1];
            int tempRes = 1;

            for (int i = 0; i <= n - k; i++)
            {
                tempRes = 1;
                for (int j = i; j < k+i; j++)
                {
                    tempRes *= (Convert.ToInt32(number[j]) - 48); 
                }
                results[i] = tempRes;
            }
            Array.Sort(results);
            Console.WriteLine(results[results.Length-1]);


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
