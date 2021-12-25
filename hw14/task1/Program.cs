using System;
using System.Threading;

namespace task1
{
    class Program
    {
        static int i = 0;
        static void Change1()
        {
            i = 1;
            Console.WriteLine(i);
        }

        static void Change2()
        {
            i = 2;
            Console.WriteLine(i);
        }

        static void Main(string[] args)
        {
            var t1 = new Thread(Change1);
            var t2 = new Thread(Change2);
            t1.Start();
            t2.Start();
            Console.WriteLine(i);

        }
    }
}
