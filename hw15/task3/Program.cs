using System;

namespace task3
{
    class Barbershop
    {
        readonly int N;
        int curCnt = 0;
        public Barbershop(int N)
        {
            this.N = N;
        }

        public void Run()
        {

        }

        public bool Add()
        {
            if (curCnt >= N)
                return false;
            curCnt++;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
