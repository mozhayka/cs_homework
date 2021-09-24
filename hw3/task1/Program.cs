using System;
using System.Collections.Generic;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new
            {
                Items = new List<int> { 1, 2, 3 }.GetEnumerator()
            };
            while (x.Items.MoveNext())
                Console.WriteLine(x.Items.Current);

        }
    }
}
