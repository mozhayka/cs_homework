using System;
using System.Diagnostics;

namespace task3
{
    class Simpl
    {
        public string Simplify(string arg)
        {
            int num, denom;
            ReadFraction(arg, out num, out denom);
            SimplifyFraction(ref num, ref denom);
            return WriteFraction(num, denom);
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a < b)
                {
                    b %= a;
                }
                else
                {
                    a %= b;
                }
            }
            return a | b;
        }

        private static void ReadFraction(string str, out int num, out int denom)
        {
            string[] numbers = str.Split('/');
            num = int.Parse(numbers[0]);
            denom = int.Parse(numbers[1]);
        }

        private static string WriteFraction(int num, int denom)
        {
            if (denom == 1)
                return $"{num}";
            return $"{num}/{denom}";
        }

        private static void SimplifyFraction(ref int num, ref int denom)
        {
            int gcd = GCD(num, denom);
            num /= gcd;
            denom /= gcd;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var s = new Simpl();
            Debug.Assert(s.Simplify("4/6") == "2/3");
            Debug.Assert(s.Simplify("10/11") == "10/11");
            Debug.Assert(s.Simplify("100/400") == "1/4");            
            Debug.Assert(s.Simplify("4/2") == "2");
        }
    }
}
