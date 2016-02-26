using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace _013LargeSum
{
    class Program
    {
        const int MAX_COUNT = 10;
        static void Main(string[] args)
        {

            BigInteger res = new BigInteger();

            int n = Convert.ToInt32(Console.ReadLine());
            string input = null;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                res += BigInteger.Parse(input);
                
            }
            string output = res.ToString();

            for (int i = 0; i < MAX_COUNT; i++)
            {
                Console.Write(output[i]);
            }

        }
    }
}
