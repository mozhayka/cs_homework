using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace task2
{
    class Permut
    {
        StringBuilder cur_word = new StringBuilder("");
        List<string> permuts = new List<string>();

        public string Permutations(string str)
        {
            GenerateAllPermuts(new StringBuilder(str));

            var ans = new StringBuilder("");
            // List имеет встроенный метод сортировки sort, так что можно отсортировать permuts
            // а чтобы список представить в виде строки и вставить между элементами определенный символ (пробел " "), можно использовать String.Join 
            foreach(var word in permuts.Distinct().OrderBy(t => t))
            {
                ans.Append($"{word} ");
            }
            ans.Remove(ans.Length - 1, 1);
            permuts.Clear();
            return ans.ToString();
        }

        private void GenerateAllPermuts(StringBuilder s)
        {
            if (s.Length == 0)
            {
                permuts.Add(cur_word.ToString());
                return;
            }
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                cur_word.Append(c);
                s.Remove(i, 1);
                GenerateAllPermuts(s);
                s.Insert(i, c);
                cur_word.Remove(cur_word.Length - 1, 1);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new Permut();
            Console.WriteLine(p.Permutations("ABCDEF"));
            //Console.WriteLine(p.Permutations("YAW"));
            //Console.WriteLine(p.Permutations("BACA"));
        }
    }
}
