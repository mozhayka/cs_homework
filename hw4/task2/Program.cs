using System;

namespace task2
{
    interface Printable1
    {
        public void Print();
    }

    interface Printable2
    {
        public void Print();
    }

    abstract class Printer
    {
        public abstract void Print();
    }

    internal class SuperPrinter : Printer, Printable1, Printable2
    {
        void Printable1.Print()
        {
            Console.WriteLine("Print 1");
        }

        void Printable2.Print()
        {
            Console.WriteLine("Print 2");
        }

        public override void Print()
        {
            Console.WriteLine("Print 3");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var p = new SuperPrinter();
            p.Print();
            ((Printable1)p).Print();
            ((Printable2)p).Print();
        }
    }
}
