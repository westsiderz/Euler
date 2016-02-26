using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _003LargestPrimeNumber
{
    
    class Program
    {
        static void FindLargest()
        {
            long n = Convert.ToInt64(Console.ReadLine());
            long divider = 2, remainder = 0;
            long numb = n;

            while (n > 1)
            {
                if (n % divider == 0)
                {
                    if (remainder < divider)
                    {
                        remainder = divider;
                    }
                    n /= divider;
                }
                else
                {
                    for (divider = 3; divider <= Math.Ceiling(Math.Sqrt(n))+1; divider += 2)
                    {
                        if (n % divider == 0)
                        {  
                            break;
                        }
                    }

                    if (n % divider == 0)
                    {
                        if (remainder < divider)
                        {
                            remainder = divider;
                        }
                        n /= divider;
                        divider = 2;
                    }
                    else
                    {
                        remainder = n;
                        break;
                    }
                    
                }

            }
            if (remainder == 0)
            {
                Console.WriteLine(numb);
            }
            else
            {
                Console.WriteLine(remainder);
            }

            
        }
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                FindLargest();
            }
        }
    }
}
