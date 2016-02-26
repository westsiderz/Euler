using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _004PalindromeProduct
{
    class Program
    {
        static List<int> allPali = new List<int>();
        static void GeneratePalis()
        {
            int result = 100001;
            int count = 1;

            while (result < 1000000)
            {
                if (count % 100 == 0)
                {
                    result += 11;
                }
                else if (count % 10 == 0)
                {
                    result += 110;
                }
                else
                {
                    result += 1100;

                }
                count++;
                allPali.Add(result);
            }
        }
        static int FindMaxElement(int input)
        {
            int minBord = 0, maxBord = allPali.Count - 1;
            int center;
            while (maxBord - minBord > 1)
            {
                center = (maxBord + minBord)/2;

                if (input <= allPali[center])
                {
                    maxBord = center;
                }
                else
                {
                    minBord = center;
                }
            }

            return minBord;
        }
        static bool IsMaxPali(int input, int minBorder)
        {
            int divider, remainder;
            for (int i = minBorder; i < 1000; i++)
            {
                divider = input / i;
                remainder = input % i;
                if (
                    (remainder == 0)
                    && (
                          (divider >= 100)
                        && (divider <= 999)
                      )
                  )
                {
                    return true;
                }
            }
            return false;
        }
        static void FindProduct()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            int maxElementIndex = FindMaxElement(input);

            int minBorder;

            for (int i = maxElementIndex; i >= 0; i--)
            {
                minBorder = (allPali[i] / 1000) + 1;
                if (IsMaxPali(allPali[i], minBorder))
                {
                    Console.WriteLine(allPali[i]);
                    return;
                }
            }

        }
        static void Main(string[] args)
        {
            GeneratePalis();
            int t = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                FindProduct();
            }
        }
    }
}
