using System;
using System.Text;

namespace task6
{
    class Program
    {
        static string stringyFib(int n)
        {
            if (n < 2)
                return "invalid";

            var ans = new string[n];
            ans[0] = "b";
            ans[1] = "a";
            for(int i = 2; i < n; i++)
            {
                ans[i] = String.Concat(ans[i - 1], ans[i - 2]);
            }

            var sb = new StringBuilder("");
            foreach(var str in ans)
            {
                sb.Append($"{str}, ");
            }

            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine(stringyFib(1));
            Console.WriteLine(stringyFib(3));
            Console.WriteLine(stringyFib(7));
        }
    }
}
