using System;
using System.Diagnostics;

namespace task3
{
    class Program
    {
        static bool IsSimilar(string s1, string s2)
        {
            var l1 = s1.Length;
            var l2 = s2.Length;
            var maxl = Math.Max(l1, l2);
            var minl = Math.Min(l1, l2);
            if (Math.Abs(l1 - l2) > 1)
                return false;

            int cps = 0; //common prefix size
            while (cps < minl && s1[cps] == s2[cps])
                cps++;
            int css = 0; //common suffix size
            while (css < minl && s1[l1 - css - 1] == s2[l2 - css - 1])
                css++;

            if (cps + css >= maxl - 1)
                return true;
            return false;
        }

        static void Test()
        {
            Debug.Assert(IsSimilar("abc", "bc") == true);
            Debug.Assert(IsSimilar("abc", "adc") == true);
            Debug.Assert(IsSimilar("abc", "abc") == true);
            Debug.Assert(IsSimilar("abcde", "abc") == false);
            Debug.Assert(IsSimilar("a", "") == true);
            Debug.Assert(IsSimilar("", "d") == true);
            Debug.Assert(IsSimilar("abcd", "adc") == false);
            Debug.Assert(IsSimilar("abcbc", "abc") == false);
            Debug.Assert(IsSimilar("aaaaa", "aaa") == false);
            Debug.Assert(IsSimilar("bbabb", "bbbb") == true);
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
