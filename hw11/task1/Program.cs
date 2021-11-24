using System;
using System.IO;

namespace task1
{
    class Program
    {
        static int[] GetRandomSuffle()
        {
            // все загружаете в память. там в задаче 100 000 000
            int n = 1000000;
            var rand = new Random();
            var arr = new int[n];
            for (int i = 0; i < n; i++)
                arr[i] = i;
            for (int i = n - 1; i >= 1; i--)
            {
                int j = rand.Next(i + 1);
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }

        static void PrintInFile()
        {
            // не стоит так хардкодить имя файла
            using (var writer = new StreamWriter("text_file.txt"))
            {
                var arr = GetRandomSuffle();
                foreach (var line in arr)
                {
                    writer.WriteLine(line.ToString("D8"));
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Current directory is '{Environment.CurrentDirectory}'");
            PrintInFile();
        }
    }
}
