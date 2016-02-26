using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _009SpecialPythagorean
{
    class Program
    {
        static void TestIt()
        {
            List<int> results = new List<int>();
            int numb = Convert.ToInt32(Console.ReadLine());
            int n = 2;
            int m = 1;
            int res = 0;
            int a, b, c;

            for (n = 2 ; n <= Math.Ceiling(Math.Sqrt(numb)); n++)
            {
                for (m = 1; m < n; m++)
                {
                    res = 2 * n * n + 2 * n * m;
                    if (res == numb)
                    {
                        a = n * n - m * m;
                        b = 2 * n * m;
                        c = n * n + m * m;

                        results.Add(a * b * c);
                        break;
                    }
                    else if (res < numb)
                    {
                        int mult = 2;
                        int tempRes = res;
                        while (res < numb)
                        {
                            res = tempRes * mult;
                            if (res == numb)
                            {
                                a = n * n - m * m;
                                b = 2 * n * m;
                                c = n * n + m * m;
                                results.Add((int)(a * b * c * Math.Pow(mult, 3)));
                                break;
                            }
                            mult++;
                        }
                    }
                    else
                    {

                    }
                }
            }


            if (results.Count == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(results.Max());
            }
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
