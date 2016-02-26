using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _005SmallestMultiple
{
    class Program
    {
        static List<int>[] matrix = new List<int>[39];
        static List<int> primes = new List<int>();
        static long[] arrSmallest = new long[40];

        static bool IsPrime(int numb)
        {
            for (int i = 2; i <= Math.Sqrt(numb); i++)
            {
                if (numb % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void FindAllPrimes()
        {
            primes.Add(2);
            for (int i = 3; i < 40; i += 2)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }
        }

        static List<int> GetPrimes(int numb)
        {
            List<int> numbs = new List<int>();
            int i = 0;
            while (numb >= primes[i])
            {
                if (numb % primes[i] == 0)
                {
                    numbs.Add(primes[i]);
                    numb /= primes[i];
                }
                else
                {
                    i++;
                }
            }
            return numbs;
        }

        static void GenerateMatrix()
        {
            for (int i = 2; i <= 40; i++)
            {
                matrix[i - 2] = new List<int>();
                matrix[i - 2].AddRange(GetPrimes(i));
            }
        }

        static void ModifyMatrix(int index, int numb)
        {
            for(int i = 0; i<index; i++)
            {
                for(int j = 0; j < matrix[i].Count; j++)
                {
                    if(matrix[i][j] == numb)
                    {
                        matrix[i][j] = 1;
                        return;
                    }
                }
            }
        }

        static void GetResults(int index)
        {
            long result = 1;
            for (int i = 0; i <= index; i++)
            {
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    result *= matrix[i][j];
                }
            }
            arrSmallest[index + 1] = result;
        }

        static void FindAllSmallest()
        {
            arrSmallest[0] = 1;
            for(int i = 0; i < 39; i++)
            {
                foreach(int el in matrix[i])
                {
                    ModifyMatrix(i, el);
                }
                GetResults(i);
            }
        }

        static void TestIt()
        {
            int index = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(arrSmallest[index - 1]);
        }
        static void Main(string[] args)
        {
            FindAllPrimes();
            GenerateMatrix();
            FindAllSmallest();
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
