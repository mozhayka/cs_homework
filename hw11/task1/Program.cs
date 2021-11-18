using System;
using System.IO;

namespace task1
{
    class Program
    {
        static int[] GetRandomSuffle()
        {
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
