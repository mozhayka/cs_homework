using System;
using static task2.Allergies;

namespace task2
{
    class Program
    {
        static void Test()
        {
            var mary = new Allergies("Mary");
            var joe = new Allergies("Joe", 65);
            var rob = new Allergies("Rob", "Peanuts Chocolate Cats Strawberries");

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();

            Console.WriteLine(mary.Name);
            Console.WriteLine(joe.Score);
            Console.WriteLine();

            Console.WriteLine(joe.IsAllergicTo(Allergen.Cats));
            Console.WriteLine(rob.IsAllergicTo("Peanuts"));
            Console.WriteLine();

            joe.AddAllergy("Cats");
            mary.AddAllergy(Allergen.Chocolate);

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();

            joe.DeleteAllergy("Cats");
            rob.DeleteAllergy(Allergen.Eggs);

            Console.WriteLine(mary);
            Console.WriteLine(joe);
            Console.WriteLine(rob);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Test();
        }
    }
}
