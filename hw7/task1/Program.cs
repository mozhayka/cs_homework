using System;
using System.Linq;

namespace task1
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

    class Concat
    {
        public static string DoConcatination(Elem[] elems, string delimeter)
        {
            return (from el in elems select el.Name)
                .Skip(3)
                .Aggregate((x, y) => x + delimeter + y);
            
        }
    }

    class Program
    {
        static void Test()
        {
            var elems = new Elem[] { new Elem("a"), new Elem("b"), 
                new Elem("c"), new Elem("d"), new Elem("e"), new Elem("f") };
            Console.WriteLine(Concat.DoConcatination(elems, ", "));
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
