using System;
using System.Collections.Generic;
using System.Linq;

namespace task5
{
    class Program
    {
        static List<string> SplitOnBucket(string s, int n)
        {
            Console.WriteLine(s);
            var words = s.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var ans = new List<string>();

            var cur_string_size = 0;
            var page_num = 0;
            var pages = (from word in words
                        select new { 
                            cur_str = cur_string_size += word.Length + 1, // это очень неудачная запись. такой код сложно поддерживать 
                            pg_num = cur_string_size <= n ? page_num : ++page_num,
                            new_cur_str = cur_string_size <= n ? cur_string_size : cur_string_size = word.Length,
                            Key = page_num, 
                            Value = word})
                        .Select(x => new {Key = x.Key, Value = x.Value})
                        .GroupBy(x => x.Key);
            foreach(var grp in pages)
            {
                ans.Add(grp
                    .Select(x => x.Value)
                    .Aggregate((x, y) => x + " " + y));
            }
            return ans;
        }

        static void Test(string s, int n)
        {
            var ans = SplitOnBucket(s, n);
            foreach (var str in ans)
            {
                Console.WriteLine(str);
            }
        }
        static void Main(string[] args)
        {
            Test("она продает морские раковины у моря", 16);
            Test("мышь прыгнула через сыр", 8);
            Test("волшебная пыль покрыла воздух", 15);
            Test("a b c d e  ", 2);
        }
    }
}
