using System;

namespace task2
{
    class ImmutablePair
    {
        private readonly int fst, snd;
        public ImmutablePair(int f, int s) 
        {
            fst = f;
            snd = s;
        }

        public ImmutablePair change(int f, int s)
        {
            var pair = new ImmutablePair(f, s);
            return pair;
        }

        public override string ToString()
        {
            return $"fst = {fst}, snd = {snd}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ImmutablePair(2, 3);
            var b = a.change(4, 5);
            Console.WriteLine(a);
            Console.WriteLine(b);
        }
    }
}
