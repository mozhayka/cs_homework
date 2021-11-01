using System;
using System.Linq;

namespace task2
{
    struct Elem
    {
        string name;
        public string Name => name;

        public Elem(string name)
        {
            this.name = name;
        }
    }

    class Program
    {
        static void Test()
        {
            var elems = new Elem[] { new Elem("a"), new Elem("b"),
                new Elem("c"), new Elem("dsff"), new Elem("e"), new Elem("foooooo") };
            var pos = -1;
            var ans = (from el in elems select el.Name)
                .Where(x => { pos++;
                    return x.Length > pos;
                });
            Console.WriteLine(ans.Aggregate((x, y) => x + ", " + y));
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
