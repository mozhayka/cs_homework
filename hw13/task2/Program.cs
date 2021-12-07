using System;
using System.Threading;

namespace task2
{
    class Program
    {
        private static readonly Mutex _mutex = new Mutex(false);

        static void Print10()
        {
            for(int i = 0; i < 10; i++)
            {
                _mutex.WaitOne();
                Console.WriteLine($"string {i}");
                Thread.Sleep(100);
                _mutex.ReleaseMutex();
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Print10);
            Thread thread2 = new Thread(Print10);

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}
