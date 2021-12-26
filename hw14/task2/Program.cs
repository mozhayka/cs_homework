using System;
using System.Threading;

namespace task2
{
    public class Foo
    {
        public void first() { Console.WriteLine("first"); }
        public void second() { Console.WriteLine("second"); }
        public void third() { Console.WriteLine("third"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var f = new Foo();
            var t1 = new Thread(f.first);
            Console.WriteLine("Hello World!");
        }
    }
}
