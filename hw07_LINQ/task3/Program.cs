using System;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Test(string s)
        {
            Console.WriteLine(s);
            var words = s.Split(" ,.:-".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var ans = words
                .GroupBy(x => x.Length)
                .OrderBy(grp => -grp.Count())
                .Select(grp => new {
                                    Name = grp.Key,
                                    Len = grp.First().Length,
                                    Count = grp.Count(),
                                    Words = grp.Select(p => p)
                                    });
                
            foreach(var grp in ans)
            {
                Console.WriteLine($"Группа {grp.Name}. Длина {grp.Len}. Количество {grp.Count} ");
                foreach(var word in grp.Words)
                {
                    Console.WriteLine(word);
                }
            }
        }
        static void Main(string[] args)
        {
            Test("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
        }
    }
}
