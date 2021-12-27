using System;
using System.Threading;
using System.Threading.Tasks;

namespace task4
{
    class Sorter
    {
        int n;
        int p;
        int[] arr;
        Task[] tasks;
        Random rand = new Random();

        public Sorter(int[] arr, int p)
        {
            n = arr.Length;
            this.p = p;
            this.arr = arr;
            tasks = new Task[p];
        }

        public int[] Sort()
        {
            for (int i = 0; i < p; i++)
            {
                var from = i * n / p;
                var to = (i + 1) * n / p;
                tasks[i] = new Task(() => BubbleSort(from, to));
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
            return Merge();
        }

        //Не понятно, как начинать слияние, если не все потоки закончили
        //Вдруг в только что законченном потоке будет элемент, который надо было вставить раньше
        private int[] Merge()
        {
            const int INF = (int) 1e9;
            var newArr = new int[n];
            var curIdx = new int[p];
            for (int i = 0; i < n; i++)
            {
                newArr[i] = INF;
                int best_j = 0;
                for (int j = 0; j < p; j++)
                {
                    if (curIdx[j] < ((j + 1) * n / p - j * n / p) &&
                        arr[curIdx[j] + j * n / p] < newArr[i])
                    {
                        newArr[i] = arr[curIdx[j] + j * n / p];
                        best_j = j;
                    }
                }
                curIdx[best_j]++;
            }
            return newArr;
        }

        private void BubbleSort(int from, int to)
        {
            Thread.Sleep(rand.Next(500, 2000));

            for (int i = from; i < to; i++)
            {
                for (int j = from; j < to; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        var t = arr[i];
                        arr[i] = arr[j];
                        arr[j] = t;
                    }
                }
            }
        }

        public void Dispose()
        {
            foreach (var task in tasks)
                task.Dispose();
        }
    }

    class Program
    {
        static void Test(int[] arr, int p = 2)
        {
            Console.Write("initial ");
            foreach (var i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            var sorter = new Sorter(arr, p);
            arr = sorter.Sort();

            Console.Write("sorted  ");
            foreach (var i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Test(new int[] { 2, 3, 4, 5, 5, 6, 1, 23, 2 });
            Test(new int[] { 3, -54, 1, 0, 345, -242, 3 }, 4);
        }
    }
}
