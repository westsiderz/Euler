using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _016PowerDigitSum
{
    class Program
    {
        static void SumDigits(BigInteger numb)
        {
            BigInteger result = 0;
            while (numb > 0)
            {
                result += numb % 10;
                numb /= 10;
            }

            Console.WriteLine(result);
        }
        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            BigInteger res = BigInteger.Pow(2, n);
            SumDigits(res);
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
