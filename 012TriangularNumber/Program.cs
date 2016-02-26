using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * Let d(n) be the number of divisors for the natural number, n.

We begin by writing the number as a product of prime factors: n = p^a*q^b*r^c...
then the number of divisors, d(n) = (a+1)(b+1)(c+1)...
 http://mathschallenge.net/library/number/number_of_divisors
 * 
 * 
 * well , all hint i can give u is for n =1000 , we have 842161320 as our triangular number which is ( (41040)*(41040 +1))/2
 */

namespace _012TriangularNumber
{
    class Program
    {
        const int MAX_DIV = 1000;
       
        static List<int> divNumbers = new List<int>();
        static List<int> primes = new List<int>();
        static List<int> primesCount = new List<int>();
        static List<int> allFirsts = new List<int>();
        static int nextPrime = 3;

        static bool IsPrime(int numb)
        {
            for (int i = 2; i <= Math.Sqrt(numb); i++)
            {
                if (numb % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static void CheckDivNumbers(int number)
        {
            int primeIndex = 0;
            int tempRes = number;
            while (tempRes > 1)
            {
                if (tempRes % primes[primeIndex] == 0)
                {
                    primesCount[primeIndex]++;
                    tempRes /= primes[primeIndex];
                }
                else
                {
                    if (primeIndex == primes.Count - 1)
                    {
                        while (!IsPrime(nextPrime))
                        {
                            nextPrime += 2;
                        }
                        primes.Add(nextPrime);
                        primesCount.Add(0);
                        nextPrime += 2;
                    }
                    primeIndex++;
                }
            }
        }

        static void GenerateAllDiv()
        {
            int divCount = 1, res = 1, ad = 2;
            divNumbers.Add(1);
            primes.Add(2);
            primesCount.Add(0);
            allFirsts.Add(1);

            while (divCount < MAX_DIV)
            {
                res += ad;
                CheckDivNumbers(res);
                divCount = 1;
                for (int i = 0; i < primesCount.Count; i++)
                {
                    divCount *= (primesCount[i] + 1);
                    primesCount[i] = 0;
                }
                divNumbers.Add(divCount);
                allFirsts.Add(res);
                ad++;
            }
        }

        

        static void TestIt()
        {
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < divNumbers.Count; i++)
            {
                if (divNumbers[i] > n)
                {
                    Console.WriteLine(allFirsts[i]);
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            GenerateAllDiv();
            for (int i = 0; i < t; i++)
            {
                TestIt();
            }
        }
    }
}
