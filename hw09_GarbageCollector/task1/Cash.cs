using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace task1
{
    class Cash
    {
        DisposableObject[] elems;
        int max_size;
        int cur_cnt = 0;
        int max_time;

        public Cash(int max_size = 10, int time = 1000)
        {
            this.max_size = max_size;
            max_time = time;
            elems = new DisposableObject[max_size];
            GC.RegisterForFullGCNotification(10, 10);
            Thread t = new Thread(new ThreadStart(CheckTheGC));
            t.Start();
        }

        public void Add()
        {
            if (cur_cnt == max_size)
            {
                Console.WriteLine("Add overflow");
                Cleanup();
            }

            for (int i = 0; i < max_size; i++)
            {
                if (elems[i] == null)
                {
                    elems[i] = new DisposableObject(max_time);
                    cur_cnt++;
                    break;
                }
            }
        }

        private void Cleanup()
        {
            Console.WriteLine("Cleanup");
            for(int i = 0; i < max_size; i++)
            {
                if (elems[i] != null && elems[i].isOld)
                {
                    elems[i].Dispose();
                    elems[i] = null;
                    cur_cnt--;
                }
            }
        }

        private void CheckTheGC()
        {
            Console.WriteLine("Waiting GC notify");
            while (true) // Wait for an Approaching Full GC
            {
                GCNotificationStatus s = GC.WaitForFullGCApproach();
                if (s == GCNotificationStatus.Succeeded)
                {
                    Console.WriteLine("GC Notification");
                    Cleanup();
                    Thread.Sleep(1000);
                }
            }
        }

    }
}
