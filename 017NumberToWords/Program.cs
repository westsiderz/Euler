using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/*
 * For non native English people: 0 - 19 "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
 * "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" 
 * 20-90: "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" 1000-1000000000 "Thousand", "Million", "Billion", "Trillion"
 * 1001 = "One Thousand One
 */

namespace _017NumberToWords
{
    class Program
    {
        const int TWENTY_OFFSET = 20;
        const int HUNDRED_OFFSET = 28;
        static string[] digits = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", 
                            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen",
                            "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety",
                            "", " Thousand ", " Million ", " Billion ", " Trillion "
                          };
        static void TestIt()
        {
            long number = Convert.ToInt64(Console.ReadLine());
            StringBuilder bld = new StringBuilder();
            StringBuilder bldTemp = new StringBuilder();
            long tempNumberT = 0, tempNumber = 0;
            int count = 0;

            if (number < 20)
            {
                Console.WriteLine(digits[number]);
                return;
            }

            while (number > 0)
            {
                tempNumberT = number % 1000;
                number /= 1000;
                if (tempNumberT == 0)
                {
                    count++;
                    continue;
                }

                tempNumber = tempNumberT / 100;
                if (tempNumber > 0)
                {
                    bldTemp.Append(digits[tempNumber] + " Hundred ");
                }
                tempNumberT %= 100;

                if (tempNumberT == 0)
                {

                }
                else if ((tempNumberT > 0) && (tempNumberT < 20))
                {
                    bldTemp.Append(digits[tempNumberT]);
                }
                else
                {
                    tempNumber = tempNumberT / 10;
                    bldTemp.Append(digits[tempNumber + TWENTY_OFFSET - 2]);
                    tempNumberT %= 10;
                    if (tempNumberT > 0)
                    {
                        bldTemp.Append(" " + digits[tempNumberT]);
                    }
                }

                bldTemp.Append(digits[HUNDRED_OFFSET + count]);

                bld.Insert(0, bldTemp);
                bldTemp.Clear();
                count++;
            }

            Console.WriteLine(bld.ToString());


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
