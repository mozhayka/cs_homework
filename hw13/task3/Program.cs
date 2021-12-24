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
        private static bool isFooWorking = true;

        public static void printFoo()
        {
            while(!isFooWorking)
                Thread.Sleep(10);
            _mutex.WaitOne();
            Console.Write($"foo");
            isFooWorking = false;
            _mutex.ReleaseMutex();
            
            
        }

        public static void printBar()
        {
            while (isFooWorking)
                Thread.Sleep(10);
            _mutex.WaitOne();
            Console.Write($"bar");
            isFooWorking = true;
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
