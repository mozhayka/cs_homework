using System;
using System.Threading;

namespace task3
{
    public class H2O : IDisposable
    {
        Semaphore oxy = new Semaphore(1, 1);
        Semaphore hydro = new Semaphore(2, 2);
        Barrier waitH2O = new Barrier(3);

        public H2O()
        {
        }

        public void Hydrogen(Action releaseHydrogen)
        {
            hydro.WaitOne();
            waitH2O.SignalAndWait();

            // releaseHydrogen() outputs "H". Do not change or remove this line. 
            releaseHydrogen();

            waitH2O.SignalAndWait();
            hydro.Release();
        }

        public void Oxygen(Action releaseOxygen)
        {
            oxy.WaitOne();
            waitH2O.SignalAndWait();

            // releaseOxygen() outputs "O". Do not change or remove this line. 
            releaseOxygen();

            waitH2O.SignalAndWait();
            oxy.Release();

        }

        public void Dispose()
        {
            oxy.Dispose();
            hydro.Dispose();
            waitH2O.Dispose();
        }
    }

    class Program
    {
        static void printOxy()
        {
            Console.Write("O");
        }

        static void printHydro()
        {
            Console.Write("H");
        }

        static void Test()
        {
            var h2o = new H2O();
            Thread H1 = new Thread(() => h2o.Hydrogen(printHydro));
            Thread H2 = new Thread(() => h2o.Hydrogen(printHydro));
            Thread H3 = new Thread(() => h2o.Hydrogen(printHydro));
            Thread H4 = new Thread(() => h2o.Hydrogen(printHydro));
            Thread H5 = new Thread(() => h2o.Hydrogen(printHydro));
            Thread H6 = new Thread(() => h2o.Hydrogen(printHydro));

            Thread O1 = new Thread(() => h2o.Oxygen(printOxy));
            Thread O2 = new Thread(() => h2o.Oxygen(printOxy));
            Thread O3 = new Thread(() => h2o.Oxygen(printOxy));

            H1.Start();
            H2.Start();
            H3.Start();
            H4.Start();
            H5.Start();
            H6.Start();

            O1.Start();
            O2.Start();
            O3.Start();

            H1.Join();
            H2.Join();
            H3.Join();
            H4.Join();
            H5.Join();
            H6.Join();

            O1.Join();
            O2.Join();
            O3.Join();
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
