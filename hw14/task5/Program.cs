using System;
using System.Threading;

namespace task5
{
    public class CMyCountdownEvent : IDisposable
    {
        int count;
        ManualResetEvent _event;
        public CMyCountdownEvent(int initialCount)
        {
            count = initialCount;
            _event = new ManualResetEvent(false);
        }

        public void Signal()
        {
            Signal(1);
        }

        public void Signal(int signalCount)
        {
            if (count < signalCount)
                throw new Exception("bad signal");
            count -= signalCount;
            if (count == 0)
            {
                _event.Set();
            }
        }

        public bool Wait(TimeSpan timeout)
        {
            return _event.WaitOne(timeout);
        }

        public void Dispose()
        {
            _event.Dispose();
        }
    }

    class Program
    {
        const int TestThreadNumber = 5;
        static CMyCountdownEvent _cde = new CMyCountdownEvent(TestThreadNumber);
        static void DoSmt()
        {
            Console.WriteLine("Do smth");
            _cde.Signal();
            Console.WriteLine("after signal");
        }

        static void Test()
        {
            Thread[] threads = new Thread[TestThreadNumber];
            for(int i = 0; i < TestThreadNumber; i++)
            {
                //int copy = i;
                threads[i] = new Thread(DoSmt);
                threads[i].Start();
            }

            Console.WriteLine("Wait for event");
            _cde.Wait(new TimeSpan(100));
            Console.WriteLine("event signaled");

            foreach (var thr in threads)
                thr.Join();
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
