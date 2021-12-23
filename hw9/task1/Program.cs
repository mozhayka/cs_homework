using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace task1
{
    class Program
    {
        private static Boolean s_carryOn;
        static void TetsOverflow() 
        {
            var cash = new Cash(10, 3000);
            for(int i = 0; i < 15; i++)
            {
                cash.Add();
            }
            Console.WriteLine("End of Test1");
        }

        static void TestGCNotification()
        {
            var cash = new Cash();
            for (int i = 0; i < 10; i++)
            {
                cash.Add();
            }

            s_carryOn = true;

            GC.RegisterForFullGCNotification(10, 10);
            Thread t = new Thread(new ThreadStart(CheckTheGC));
            t.Start();

            Int32 secondsPassed = 0;
            ArrayList data = new ArrayList();
            while (s_carryOn)
            {
                Console.WriteLine("{0} seconds passed", secondsPassed++);

                for (Int32 i = 0; i < 1000; i++)
                    data.Add(new Byte[1000]);
                Thread.Sleep(1000);
            }

            Console.WriteLine("End of Test2");

        }

        static void Main(string[] args)
        {
            TetsOverflow();
            TestGCNotification();
        }

        private static void CheckTheGC()
        {
            while (true) // Wait for an Approaching Full GC
            {
                GCNotificationStatus s = GC.WaitForFullGCApproach();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("Full GC Nears");
                    break;
                }
            }

            while (true) // Wait until the Full GC has finished
            {
                GCNotificationStatus s = GC.WaitForFullGCComplete();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("Full GC Complete");
                    break;
                }
            }

            s_carryOn = false;
        }
    }
}
