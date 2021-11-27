using System;
using System.Collections;

namespace task5
{
    class Program
    {
        public class Comparator : IComparer
        {
            int IComparer.Compare(Object x, Object y)
            {
                var c1 = (char)x;
                var c2 = (char)y;

                if(c1 >= '0' && c1 <= '9')
                {
                    if(c2 >= '0' && c2 <= '9')
                        return c1.CompareTo(c2);
                    else
                        return 1;
                }
                if (c2 >= '0' && c2 <= '9')
                    return -1;

                var C1 = Char.ToUpper(c1);
                var C2 = Char.ToUpper(c2);
                if(C1 == C2)
                {
                    if (c1 == C1 && c2 == C2 || c1 != C1 && c2 != C2)
                        return 0;
                    if (c1 == C1)
                        return 1;
                    else
                        return -1;
                }
                return C1.CompareTo(C2);
            }
        }
        static string sorting(string s)
        {
            var ans = s.ToCharArray();
            Array.Sort(ans, new Comparator());
            return new string(ans);
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"eA2a1E -> {sorting("eA2a1E")}");
            Console.WriteLine($"Re4r -> {sorting("Re4r")}");
            Console.WriteLine($"6jnM31Q -> {sorting("6jnM31Q")}");
            Console.WriteLine($"846ZIbo -> {sorting("846ZIbo")}");
        }
    }
}
