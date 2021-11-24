using System;
using System.IO;

namespace task3
{
    class Program
    {
        static string findFile(string file_name, DirectoryInfo cur_dir)
        {
            var files = cur_dir.GetFiles();

            foreach (var file in files)
            {
                if (file.Name == file_name)
                {
                    return file.FullName;
                }
            }

            foreach (DirectoryInfo dir in cur_dir.GetDirectories())
            {
                var ans = findFile(file_name, dir);
                if (ans != null)
                    return ans;
            }

            return null;
        }

        static string findFile(string file_name)
        {
            var root = new DirectoryInfo(@"D:\\Homework/5sem/CS"); // слишком долго работает, если начать искать ниже
            Console.WriteLine(root.FullName);
            return findFile(file_name, root);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"found {findFile("fileToFind.cs")}");
        }
    }
}
