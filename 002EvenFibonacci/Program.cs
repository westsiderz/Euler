using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _002EvenFibonacci
{
    class Program
    {
        static void GetResult()
        {
            long n = Convert.ToInt64(Console.ReadLine());
            BigInteger result = 0;
            long a = 2, b = 8, tempB = 8;
            result = a + b;
            b = (4 * b) + a;
            a = tempB;
            while (b <= n)
            {
                result += b;
                tempB = b;
                b = (4 * b) + a;
                a = tempB;
            }

            Console.WriteLine(result);
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                GetResult();
            }
        }
    }
}
