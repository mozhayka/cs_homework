using System;
using System.Collections.Generic;

namespace task4
{
    class Divisors
    {
        public string ExpressFactors(int n)
        {
            if (n <= 0)
                throw new Exception("negative number");
            if (n == 1)
                return "1";

            var divisors = new Dictionary<int, int>();
            var d = 2;
            while (n > 1 && d <= n)
            {
                if (n % d == 0)
                {
                    n /= d;
                    if (!divisors.ContainsKey(d))
                        divisors.Add(d, 0);
                    divisors[d]++;
                }
                else
                {
                    d++;
                }
            }

            string ans = "";
            foreach(var div in divisors.Keys)
            {
                if (divisors[div] > 1)
                    ans += $"{div}^{divisors[div]}";
                else
                    ans += $"{div}";
                ans += " x ";
            }

            return ans.Substring(0, ans.Length - 3); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var d = new Divisors();
            Console.WriteLine(d.ExpressFactors(1));
            Console.WriteLine(d.ExpressFactors(2));
            Console.WriteLine(d.ExpressFactors(4));
            Console.WriteLine(d.ExpressFactors(6));
            Console.WriteLine(d.ExpressFactors(10));
            Console.WriteLine(d.ExpressFactors(60));
        }
    }
}
