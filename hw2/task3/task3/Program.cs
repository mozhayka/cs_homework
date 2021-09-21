using System;

namespace task3
{
    struct Pair
    {
        int fst, snd;

        public Pair(int f, int s)
        {
            fst = f;
            snd = s;
        }
        
        public void changeFst(int f)
        {
            fst = f;
        }

        public void changeSnd(int s)
        {
            snd = s;
        }

        public int getSum()
        {
            return fst + snd;
        }
    }

    struct Triple
    {
        int fst, snd, trd;

        public Triple(int f, int s, int t)
        {
            fst = f;
            snd = s;
            trd = t;
        }

        public void changeFst(int f)
        {
            fst = f;
        }

        public void changeSnd(int s)
        {
            snd = s;
        }

        public void changeTrd(int t)
        {
            trd = t;
        }

        public int getSum()
        {
            return fst + snd + trd;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pair = new Pair(2, 3);
            var triple = new Triple(1, 2, 3);
            pair.changeFst(5);
            triple.changeFst(5);
            Console.WriteLine(pair.getSum());
            Console.WriteLine(triple.getSum());
        }
    }
}
