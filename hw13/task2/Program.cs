using System;
using System.Threading;

namespace task2
{
    class Program
    {
        private static readonly Mutex _mutex = new Mutex(false);
        private static bool isFirstWorking = true;
        static void Print10_1()
        {
            for(int i = 0; i < 10; i++)
            {
                while(!isFirstWorking)
                    Thread.Sleep(10);
                _mutex.WaitOne();
                Console.WriteLine($"string {i}");
                isFirstWorking = false;
                _mutex.ReleaseMutex();
            }
        }

        static void Print10_2()
        {
            for (int i = 0; i < 10; i++)
            {
                while (isFirstWorking)
                    Thread.Sleep(10);
                _mutex.WaitOne();
                Console.WriteLine($"string {i}");
                isFirstWorking = true;
                _mutex.ReleaseMutex();
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Print10_1);
            Thread thread2 = new Thread(Print10_2);

            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
        }
    }
}
