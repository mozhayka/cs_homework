using System;
using System.Linq;
using System.Text;

namespace task4
{
    class Program
    {
        static string Merge(string s1, string s2)
        {
            if (s1 == s2)
                return s1;
            return s1 + ' ' + s2;
        }

        static string MergeStrings(string a, string b)
        {
            var s1 = a.Split(' ');
            var s2 = b.Split(' ');
            var ans = s1.Zip(s2, Merge);

            var sb = new StringBuilder();
            foreach (var word in ans)
                sb.Append($"{word} ");
            
            if (s1.Length > s2.Length)
            {
                for (int i = s2.Length; i < s1.Length; i++)
                    sb.Append(s1[i]);
            }

            if (s1.Length < s2.Length)
            {
                for (int i = s1.Length; i < s2.Length; i++)
                    sb.Append(s2[i]);
            }
            return sb.ToString();
        }

        static void Main(string[] args)
        {
            var s1 = "Шла Маша по шоссе пешком";
            var s2 = "Шла Саша по горе";
            Console.WriteLine(MergeStrings(s1, s2));
        }
    }
}
