using System;
using System.Threading;
using System.Threading.Tasks;

namespace task1
{
    class Jar
    {
        readonly int beesCnt;
        readonly int capacity;
        int curHoney = 0;
        Random rand = new Random();
        CountdownEvent bear;
        Mutex m = new Mutex();

        public Jar(int N, int X)
        {
            beesCnt = N;
            capacity = X;
            bear = new CountdownEvent(X);
        }

        public void Run()
        {            
            var bearTask = new Task(() => EatAll());
            bearTask.Start();
            var tasks = new Task[beesCnt];
            for (int i = 0; i < beesCnt; i++)
            {
                tasks[i] = new Task(() => AddHoney());
                tasks[i].Start();
                for (int j = 0; j < capacity; j++)
                {
                    tasks[i].ContinueWith(t => AddHoney()); 
                }
            }
            bearTask.Wait();
        }

        private void AddHoney()
        {
            Thread.Sleep(rand.Next(500, 1000));
            m.WaitOne();
            curHoney++;
            bear.Signal();
            Console.WriteLine("+ 1");
            m.ReleaseMutex();
        }

        private void EatAll()
        {
            bear.Wait();
            m.WaitOne();
            curHoney = 0;
            Console.WriteLine($"bear is eating honey");
            bear.Reset();
            m.ReleaseMutex();
        }

        public void Dispose()
        {
            bear.Dispose();
            m.Dispose();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Jar j = new Jar(3, 10);
            j.Run();
        }
    }
}
