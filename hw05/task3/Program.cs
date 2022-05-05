using System;

namespace task3
{
    class Calc
    {
        public int SunLounger(string s)
        {
            var place = s.ToCharArray();
            int max_cnt = 0;
            int n = place.Length;
            for(int i = 0; i < n; i++)
            {
                if (place[i] != '0' && place[i] != '1')
                    throw new Exception("bad string");
                if (place[i] == '1')
                    continue;
                if (i == 0 && n > 1 && place[1] == '1')
                    continue;
                if (i == n - 1 && n > 1 && place[n - 2] == '1')
                    continue;
                if (i == 0 || i == n - 1 || place[i - 1] == '0' && place[i + 1] == '0')
                {
                    place[i] = '1';
                    max_cnt++;
                }
            }
            return max_cnt;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var c = new Calc();
            Console.WriteLine(c.SunLounger("10001"));
            Console.WriteLine(c.SunLounger("00101"));
            Console.WriteLine(c.SunLounger("0"));
            Console.WriteLine(c.SunLounger("000"));
        }
    }
}
