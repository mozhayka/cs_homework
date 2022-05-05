using System;
using System.Linq;

namespace task6
{
    class Program
    {
        static long[] maxmin(long n)
        {
            long mi = findMin(n);
            long q = Convert.ToInt32(Math.Pow(10, n.ToString().Length)) - 1;
            long ma = q - findMin(q - n);
            return new long[] { mi, ma };
        }

        static long findMin(long n)
        {
            int idx = 0;
            var arr = n.ToString()
                .Select(o => new { Value = Convert.ToInt32(o) - 48, Idx = idx++ })
                .ToArray(); 
            var sorted_arr = arr
                .Select(x => x.Value)
                .OrderBy(x => x);

            var first_num_to_swap = arr.Zip(sorted_arr, (x, y) => new { idx = x.Idx, fst = x.Value, snd = y })
                .FirstOrDefault(p => p.fst != p.snd);

            if (first_num_to_swap == null)
                return n;
            var snd_num_to_swap = arr
                .Skip(first_num_to_swap.idx)
                .Last(x => x.Value == first_num_to_swap.snd);

            var diff = Convert.ToInt32(
                Math.Pow(10, arr.Length - first_num_to_swap.idx - 1) -
                Math.Pow(10, arr.Length - snd_num_to_swap.Idx - 1)) *
                (first_num_to_swap.fst - snd_num_to_swap.Value);
            return n - diff;
        }

        // Работает только для чисел без 0
        static void Test(long n)
        {
            var ans = maxmin(n);
            Console.WriteLine($"{ans[0]}, {ans[1]}");
        }
        static void Main(string[] args)
        {
            Test(1325);
            Test(87654321);
            Test(98761);
            Test(13250);
        }
    }
}
