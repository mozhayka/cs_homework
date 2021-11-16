using System;
using System.Linq;

namespace task3
{
    class Envelope
    {
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public Envelope(int h, int w)
        {
            Height = h;
            Weight = w;
        }

        public static bool operator >(Envelope c1, Envelope c2)
        {
            return c1.Height > c2.Height && c1.Weight > c2.Weight;
        }
        public static bool operator <(Envelope c1, Envelope c2)
        {
            return c1.Height < c2.Height && c1.Weight < c2.Weight;
        }
    }   

    class Program
    {
        static int MaxMatryoshka(Envelope[] envelopes)
        {
            int n = envelopes.Length;
            var maxLen = new int[n];
            var arr = envelopes
                .OrderBy(x => x.Weight)
                .ThenBy(x => x.Height)
                .ToArray();
            for (int i = 0; i < n; i++)
            {
                maxLen[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        maxLen[i] = Math.Max(maxLen[i], maxLen[j] + 1);
                    }
                }
            }
            return maxLen[n - 1];
        }
        static void Main(string[] args)
        {
            var arr = new Envelope[] { new Envelope(5, 4), new Envelope(6, 4),
                new Envelope(6, 7), new Envelope(2, 3)};
            Console.WriteLine(MaxMatryoshka(arr));
            Console.WriteLine(MaxMatryoshka(new Envelope[] { new Envelope(1, 1), new Envelope(1, 1) }));
        }
    }
}
