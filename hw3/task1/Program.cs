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
            {
                Console.WriteLine(x.Items.Current);
            }
            // Будет выводиться 0 бесконечно, так как new List<int> { 1, 2, 3 } будет стерт из кучи гарбадж коллектором, так как мы не храним ссылок на него
            // Если в коллекцию вносятся изменения, такие как добавление, изменение или удаление элементов, поведение параметра MoveNext не определено.
            // поэтому MoveNext может всегда возвращать True, а Current может возвращать 0
        }
    }
}
