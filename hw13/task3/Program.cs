using System;
using System.Threading;

namespace task3
{
    public class FooBar
    {
        private int n;
        public FooBar(int n)
        {
            this.n = n;
        }
        public void Foo(Action printFoo)
        {

            for (int i = 0; i < n; i++)
            {

                // printFoo() outputs "foo". Do not change or remove this line.
                printFoo();
            }
        }
        public void Bar(Action printBar)
        {

            for (int i = 0; i < n; i++)
            {

                // printBar() outputs "bar". Do not change or remove this line.
                printBar();
            }
        }
    }

    public class PrintFooBar
    {
        private static readonly Mutex _mutex = new Mutex(false);

        public static void printFoo()
        {
            _mutex.WaitOne();
            Console.Write($"foo");
            _mutex.ReleaseMutex();
            Thread.Sleep(1000);
        }

        public static void printBar()
        {
            Thread.Sleep(1000);
            _mutex.WaitOne();
            Console.Write($"bar");
            _mutex.ReleaseMutex();
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var fb = new FooBar(10);
            Thread thread1 = new Thread(() => fb.Foo(PrintFooBar.printFoo));
            Thread thread2 = new Thread(() => fb.Bar(PrintFooBar.printBar));
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}
