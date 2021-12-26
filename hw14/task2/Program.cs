using System;
using System.Threading;

namespace task2
{
    public class Foo
    {
        public readonly AutoResetEvent _event1 = new AutoResetEvent(false);
        private readonly AutoResetEvent _event2 = new AutoResetEvent(false);
        private readonly AutoResetEvent _event3 = new AutoResetEvent(false);

        public void first() { print("first"); }
        public void second() { print("second"); }
        public void third() { print("third"); }

        private void print(string s)
        {
            if(s == "first")
            {
                _event1.WaitOne();
                Console.WriteLine(s);
                _event2.Set();
            }

            if (s == "second")
            {
                _event2.WaitOne();
                Console.WriteLine(s);
                _event3.Set();
            }

            if (s == "third")
            {
                _event3.WaitOne();
                Console.WriteLine(s);
            }
        }
    }

    class Program
    {
        static void Test(int[] ord)
        {            
            var f = new Foo();
            var t = new Thread[3];
            t[0] = new Thread(f.first);
            t[1] = new Thread(f.second);
            t[2] = new Thread(f.third);

            
            foreach(var i in ord)
            {
                t[i - 1].Start();
            }
            f._event1.Set();
            foreach (var thr in t)
                thr.Join();
        }
        static void Main(string[] args)
        {

            Test(new int[] { 2, 3, 1 });
        }
    }
}
