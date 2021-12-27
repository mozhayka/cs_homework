using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace task3
{
    class Barbershop : IDisposable
    {
        readonly int N;
        int curCnt = 0;
        Task task; // лучше переменным давать более осмысленные имена
        AutoResetEvent _notify = new AutoResetEvent(false);
        Mutex m = new Mutex();
        Mutex barber = new Mutex();
        Random rand = new Random();
        Task lastTask;

        public Barbershop(int N)
        {
            this.N = N;
            task = new Task(() => Sleep());
        }

        public void Run()
        {
            task.Start();
        }

        public bool Add()
        {
            m.WaitOne();
            Console.WriteLine("Try to add");
            if (curCnt >= N)
            {
                Console.WriteLine("Queue is full");
                return false;
            }
            curCnt++;
            lastTask = task.ContinueWith(t => Haircut());
            Console.WriteLine("Succesfully added");

            _notify.Set();
            m.ReleaseMutex();
            return true;
        }

        public void WaitLastHaircut()
        {
            lastTask.Wait();
        }

        public void Dispose()
        {
            task.Dispose();
            _notify.Dispose();
            m.Dispose();
            barber.Dispose();
            lastTask.Dispose();
        }

        private void Haircut()
        {
            barber.WaitOne();
            Console.WriteLine("Haircutting");
            Thread.Sleep(rand.Next(500, 1000));
            curCnt--;
            if(curCnt == 0)
            {
                _notify.Reset();
                lastTask = task.ContinueWith(t => Sleep(), TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            Console.WriteLine("Haircut ended");
            barber.ReleaseMutex();
        }

        private void Sleep()
        {
            barber.WaitOne();
            Console.WriteLine("Sleep");
            _notify.WaitOne();
            Console.WriteLine("Awake");
            barber.ReleaseMutex();
        }
    }

    class Program
    {
        static void Test()
        {
            var b = new Barbershop(3);
            b.Add();
            b.Add();
            b.Run();
            b.Add();
            b.Add();
            Thread.Sleep(5000);
            b.Add();
            b.WaitLastHaircut();
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
