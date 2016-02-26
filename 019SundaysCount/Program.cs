using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Zeller's Congruence
 * 
 * Algorithm Z(y, m, d)
Input: The year y, month m (1 ≤ m ≤ 12), and day d (1 ≤ d ≤ 31).
Output: The day of the week.
t ← (0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4)
n ← (Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday)
if m < 3
y ← y - 1
w ← (y + ⌊y/4⌋ - ⌊y/100⌋ + ⌊y/400⌋ + tm-1 + d) mod 7
return nw
 */

namespace _019SundaysCount
{
    class Program
    {
        static int[] t = { 0, 3, 2, 5, 0, 3, 5, 1, 4, 6, 2, 4 };
        static void TestIt()
        {

            string[] input = new string[3];
            long[] year = new long[2];
            int[] month = new int[2];
            int[] day = new int[2];
            int dayOfWeek = 0;
            int count = 0;

            for (int i = 0; i < 2; i++)
            {
                input = Console.ReadLine().Split();
                year[i] = Convert.ToInt64(input[0]);
                month[i] = Convert.ToInt32(input[1]);
                day[i] = Convert.ToInt32(input[2]);
            }

            long yr;
            
            // If the selected day is not the first of the month
            if (day[0] > 1)
            {
                month[0] += 1;
                if (month[0] == 13)
                {
                    month[0] = 1;
                    year[0]++;
                }
                day[0] = 1;
            }

            while (year[0] <= year[1])
            {
                if ((year[0] == year[1]) && (month[0] > month[1]))
                {
                    break;
                }
                yr = year[0];
                if (month[0] < 3)
                {
                    yr -= 1;
                }

                dayOfWeek = (int)((yr + yr / 4 - yr / 100 + yr / 400 + t[month[0] - 1] + day[0]) % 7);

                if (dayOfWeek == 0)
                {
                    count++;
                }

                month[0]++;

                if (month[0] > 12)
                {
                    month[0] = 1;
                    year[0]++;
                }
            }

            Console.WriteLine(count);
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
