using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _011LargestProductInGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 20;

            int[,] arr = new int[ARRAY_SIZE,ARRAY_SIZE];
            List<int> results = new List<int>();
            string[] input = new string[20];
            int res;

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                input = Console.ReadLine().Split(' ');
                for (int j = 0; j < ARRAY_SIZE; j++)
                {
                    arr[i,j] = Convert.ToInt32(input[j]);
                }             
            }

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j <= ARRAY_SIZE - 4; j++)
                {
                    res = 1;
                    for (int k = j; k < j + 4; k++)
                    {
                        res *= arr[i, k];
                    }
                    results.Add(res);
                }
            }

            for (int j = 0; j < ARRAY_SIZE; j++)
            {
                for (int i = 0; i <= ARRAY_SIZE - 4; i++)
                {
                    res = 1;
                    for (int k = i; k < i + 4; k++)
                    {
                        res *= arr[k, j];
                    }
                    results.Add(res);
                }
            }

            for (int i = 3; i < ARRAY_SIZE; i++)
            {
                for (int j = 0; j <= ARRAY_SIZE - 4; j++)
                {
                    res = 1;
                    for (int k = 0; k < 4; k++)
                    {
                        res *= arr[i - k, j + k];
                    }
                    results.Add(res);
                }
            }

            for (int i = ARRAY_SIZE - 4; i >= 0; i--)
            {
                for (int j = 0; j <= ARRAY_SIZE - 4; j++)
                {
                    res = 1;
                    for (int k = 0; k < 4; k++)
                    {
                        res *= arr[i + k, j + k];
                    }
                    results.Add(res);
                }
            }

            Console.WriteLine(results.Max());
						
        }
    }
}
