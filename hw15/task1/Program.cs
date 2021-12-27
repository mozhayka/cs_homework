using System;
using System.Threading;
using System.Threading.Tasks;

namespace task1
{
    class Jar : IDisposable
    {
        readonly int beesCnt;
        readonly int capacity;
        int curHoney = 0;
        private bool bearIsEating = false;
        Random rand = new Random();
        CountdownEvent notifyBear;
        Mutex m = new Mutex();
        Task[] bees;
        Task bear;


        public Jar(int N, int X)
        {
            beesCnt = N;
            capacity = X;
            notifyBear = new CountdownEvent(X);
            bear = new Task(() => EatAll());
            bees = new Task[N];
            for (int i = 0; i < N; i++)
            {
                var copy = i;
                bees[i] = new Task(() => AddHoney(copy));
            }
        }

        public void Run()
        {            
            bear.Start();
            for (int i = 0; i < beesCnt; i++)
                bees[i].Start();
        }

        public void WaitBear()
        {
            bear.Wait();
        }

        private void AddHoney(int num)
        {
            Thread.Sleep(rand.Next(500, 1000));
            m.WaitOne();
            if (!bearIsEating)
            {
                curHoney++;
                notifyBear.Signal();
                Console.WriteLine("+ 1");
                if (curHoney == capacity)
                {
                    bearIsEating = true;
                }
            }
            bees[num].ContinueWith(t => AddHoney(num));
            m.ReleaseMutex();
        }

        private void EatAll()
        {
            Console.WriteLine($"bear is sleeping");
            notifyBear.Wait();
            m.WaitOne();
            curHoney = 0;
            Console.WriteLine($"bear is eating honey");
            notifyBear.Reset();
            bearIsEating = false;
            bear = bear.ContinueWith(t => EatAll());
            m.ReleaseMutex();
        }

        public void Dispose()
        {
            notifyBear.Dispose();
            m.Dispose();
            bear.Dispose();
            foreach (var bee in bees)
                bee.Dispose();
        }
    }

    class Program
    {
        static void Test()
        {
            Jar j = new Jar(3, 10);
            j.Run();
            j.WaitBear();
            j.WaitBear();
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
