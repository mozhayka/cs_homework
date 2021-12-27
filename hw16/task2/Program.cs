using System;
using System.Threading;

namespace task2
{
    class Arr : IDisposable
    {
        int[] a;
        int[] cur_position;
        int n;
        Random rand = new Random();
        ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public Arr(int[] arr)
        {
            a = arr;
            n = arr.Length;
            cur_position = new int[n]; // Хранит, элемент с каким изначальным номером стоит сейчас на позиции i
            for (int i = 0; i < n; i++)
                cur_position[i] = i;
        }

        public void Run()
        {
            Thread TMin = new Thread(Min);
            Thread TAvg = new Thread(Avg);
            Thread TSort = new Thread(Sort);
            Thread TSwap = new Thread(Swap);

            TMin.Start();
            TAvg.Start();
            TSort.Start();
            TSwap.Start();

            TMin.Join();
            TAvg.Join();
            TSort.Join();
            TSwap.Join();
        }

        private void Swap(ref int a, ref int b)
        {
            var t = a;
            a = b;
            b = t;
        }

        private void Sort()
        {
            Thread.Sleep(100);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    _lock.EnterWriteLock();
                    Console.WriteLine($"Sort {i} {j}");
                    Thread.Sleep(100);

                    if (a[i] < a[j])
                    {
                        Swap(ref a[i], ref a[j]);
                        Swap(ref cur_position[i], ref cur_position[j]);
                    }
                    _lock.ExitWriteLock();
                } 
            }
        }

        private void Swap()
        {
            Thread.Sleep(100);
            for (int _ = 0; _ < n; _++)
            {
                _lock.EnterWriteLock();
                int i = rand.Next(0, n);
                int j = rand.Next(0, n);
                Console.WriteLine($"Swap {i} {j}");
                Thread.Sleep(100);

                Swap(ref a[i], ref a[j]);
                Swap(ref cur_position[i], ref cur_position[j]);
                _lock.ExitWriteLock();
            }
        }

        private void Avg()
        {
            Thread.Sleep(100);
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                _lock.EnterReadLock();
                Console.WriteLine($"AVG {i}");
                Thread.Sleep(100);

                int j = 0;
                while (cur_position[j] != i)
                    j++;
                sum += a[j]; 
                _lock.ExitReadLock();
            }

            double avg = (double)sum / n;
            Console.WriteLine($"Avg is {avg}");
        }

        private void Min()
        {
            Thread.Sleep(100);
            int min = a[0];
            for (int i = 0; i < n; i++)
            {
                _lock.EnterReadLock();
                Console.WriteLine($"MIN {i}");
                Thread.Sleep(100);

                int j = 0;
                while (cur_position[j] != i)
                    j++;
                min = Math.Min(min, a[j]);
                _lock.ExitReadLock();
            }
            Console.WriteLine($"min is {min}");
        }

        public void Dispose()
        {
            _lock.Dispose();
        }
    }

    class Program
    {
        static void Test(int[] arr)
        {
            var a = new Arr(arr);
            a.Run();
        }
        
        static void Main(string[] args)
        {
            Test(new int[] { 2, 3, 4, 1, 4, 2 });
        }
    }
}
