using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace PanDigital
{
    class Program
    {
        static bool CheckPan(string input, int k)
        {
            string start = input.Substring(0, k);
            string end = input.Substring(input.Length - k, k);

            char kk = (char)((int)'0' + k);
            for (char i = '1'; i <= kk; i++)
            {
                if ((start.Contains((char)i) == false) || (end.Contains((char)i) == false))
                {
                    return false;
                }
            }
            return true;
        }
        static void Main(string[] args)
        {
            BigInteger a = Convert.ToInt32(Console.ReadLine());
            BigInteger b = Convert.ToInt32(Console.ReadLine());
            BigInteger result = 0;
            int k = Convert.ToInt32(Console.ReadLine());
            int n = 1;
            /*string input;
            input = a.ToString();
            if (input.Length >= k)
            {
                if (CheckPan(input, k))
                {
                    Console.WriteLine(n);
                    return;
                }
            }
            n++;
            input = b.ToString();
            if (input.Length >= k)
            {
                if (CheckPan(input, k))
                {
                    Console.WriteLine(n);
                    return;
                }
            }*/
            while (n < 2000000)
            {
                result = a + b;
                //input = result.ToString();
                a = b;
                b = result;
                n++;
                /*if (input.Length < k)
                {
                    continue;
                }

                if (CheckPan(input, k))
                {
                    Console.WriteLine(n);
                    return;
                }*/
            }
            //Console.WriteLine("no solution");
            Console.WriteLine(result);
        }
    }
}
