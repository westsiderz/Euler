using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Euler
{
    class Program
    {
        static bool CheckPan(string start, string end, int k)
        {
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
            int kNumb;
            int carrier = 0;
            int n = 3;
            List<int> aNumb = new List<int>();
            List<int> bNumb = new List<int>();
            List<int> result;

            aNumb.Add(Convert.ToSByte(Console.ReadLine()));
            bNumb.Add(Convert.ToSByte(Console.ReadLine()));
            kNumb = Convert.ToSByte(Console.ReadLine());
            int tempRes;

            while (n <= 2000000)
            {
                result = new List<int>();
                for (int i = 0; i < bNumb.Count; i++)
                {
                    if (i < aNumb.Count)
                    {
                        tempRes = aNumb[i] + bNumb[i] + carrier;
                    }
                    else
                    {
                        tempRes = bNumb[i] + carrier;
                    }
                    result.Add(tempRes % 10);
                    carrier = tempRes / 10;
                }
                if (carrier > 0)
                {
                    result.Add(carrier);
                    carrier = 0;
                }
                aNumb = bNumb;
                bNumb = result;
                n++;

                if (result.Count < kNumb)
                {
                    continue;
                }
                else
                {
                    StringBuilder tempStr1 = new StringBuilder();
                    StringBuilder tempStr2 = new StringBuilder();
                    for (int i = 0; i < kNumb; i++)
                    {
                        tempStr1.Append(result[i]);
                        tempStr2.Append(result[result.Count - i - 1]);
                    }
                    if (CheckPan(tempStr1.ToString(), tempStr2.ToString(), kNumb))
                    {
                        Console.WriteLine(n-1);
                        return;
                    }

                }
                
                
            }
            Console.WriteLine(-1);
        }
    }
}
