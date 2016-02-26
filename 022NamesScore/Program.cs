using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _022NamesScore
{
    class Program
    {
        static int GetScore(string name)
        {
            int score = 0;

            for (int i = 0; i < name.Length; i++)
            {
                score += (int)name[i] - 64;
            }

            return score;
        }
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string name = null;
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                name = Console.ReadLine();
                dict.Add(name, GetScore(name));
            }

            Array keys = dict.Keys.ToArray();

            int q = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < q; i++)
            {
                string search = Console.ReadLine();
                for (int j = 0; j < keys.Length; j++)
                {
                    if (keys.GetValue(j).Equals(search))
                    {
                        Console.WriteLine(dict[search] * (j + 1));
                    }
                }
            }

        }
    }
}
