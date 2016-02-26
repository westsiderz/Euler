using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _018MaximumPathSum
{
    class Program
    {
        static int n;
        static List<int> results;
        static int[,] arr; 

        static void SumIt(int res, int i, int j)
        {
            if (i == n - 1)
            {
                results.Add(res);
                return;
            }

            i++;
            SumIt(res + arr[i,j], i, j);
            SumIt(res + arr[i, ++j], i, j);
        }

        static void TestIt()
        {
            n = Convert.ToInt32(Console.ReadLine());
            results = new List<int>();
            arr = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                for (int j = 0; j < input.Length; j++)
                {
                    arr[i, j] = Convert.ToInt32(input[j]);
                }
            }

            SumIt(arr[0,0], 0, 0);
            
            Console.WriteLine(results.Max());
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
