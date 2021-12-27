using System;
using System.Threading;
using System.Threading.Tasks;

namespace task3
{
    class Barbershop : IDisposable
    {
        readonly int N;
        int curCnt = 0;
        Task task;
        AutoResetEvent _notify = new AutoResetEvent(false);
        Mutex m = new Mutex();
        Mutex barber = new Mutex();
        Random rand = new Random();

        public Barbershop(int N)
        {
            this.N = N;
            task = new Task(() => Sleep());
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
            task.ContinueWith(t => Haircut());
            Console.WriteLine("Succesfully added");

            _notify.Set();
            m.ReleaseMutex();
            return true;
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
                task.ContinueWith(t => Sleep());
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

        public void Dispose()
        {
            _notify.Dispose();
            m.Dispose();
            barber.Dispose();
        }
    }
    class Program
    {
        static void Test()
        {
            var b = new Barbershop(3);
            b.Add();
            b.Add();
            b.Add();
            b.Add();
            Thread.Sleep(5000);
            b.Add();
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
