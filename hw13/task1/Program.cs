using System;
using System.Threading;

namespace task1
{
    class Program
    {
        static object l1 = new object();
        static object l2 = new object();
        private static void Thread1()
        {
            lock (l1)
            {
                Console.WriteLine("Thread1 lock1");
                Thread.Sleep(1000);
                lock(l2)
                {
                    Console.WriteLine("Thread1 lock2");
                }
            }
        }

        private static void Thread2(object obj)
        {
            lock (l2)
            {
                Console.WriteLine("Thread2 lock2");
                Thread.Sleep(1000);
                lock (l1)
                {
                    Console.WriteLine("Thread2 lock1");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(Thread1);
            thread1.Start();
            

            Thread thread2 = new Thread(Thread2);
            thread2.Start();
            
            thread1.Join();
            thread2.Join();
            Console.WriteLine("Hello World!");
        }
    }
}
