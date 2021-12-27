using System;
using System.Threading;

namespace task1
{
    public class ZeroEvenOdd : IDisposable
    {
        private int n;
        AutoResetEvent zero_notify = new AutoResetEvent(true);
        AutoResetEvent even_notify = new AutoResetEvent(false);
        AutoResetEvent odd_notify = new AutoResetEvent(false);

        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }
        // printNumber(x) outputs "x", where x is an integer. 

        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                zero_notify.WaitOne();
                printNumber(0);
                zero_notify.Reset();

                if (i % 2 == 0)
                    even_notify.Set();
                else
                    odd_notify.Set();

                
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                even_notify.WaitOne();
                printNumber(i);
                even_notify.Reset();
                zero_notify.Set();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                odd_notify.WaitOne();
                printNumber(i);
                odd_notify.Reset();
                zero_notify.Set();
            }
        }

        public void Dispose()
        {
            zero_notify.Dispose();
            odd_notify.Dispose();
            even_notify.Dispose();
        }
    }

    class Program
    {
        static void print(int x)
        {
            Console.Write(x);
        }

        static void Test(int n)
        {
            var zeo = new ZeroEvenOdd(n);
            Thread A = new Thread(() => zeo.Zero(print));
            Thread B = new Thread(() => zeo.Even(print));
            Thread C = new Thread(() => zeo.Odd(print));
            A.Start();
            B.Start();
            C.Start();

            A.Join();
            B.Join();
            C.Join();
        }

        static void Main(string[] args)
        {
            Test(5);
        }
    }
}
