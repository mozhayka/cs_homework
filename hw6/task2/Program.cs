using System;
using System.Collections.Generic;

namespace task2
{
    class Person
    {
        string name;
        public string Name { get { return name; } }
        int age;
        public int Age { get { return age; } }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            return $"{name} {age} ";
        }
    }

    class PeopleNameComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Name.Length > p2.Name.Length)
                return 1;
            if (p1.Name.Length < p2.Name.Length)
                return -1;
            char s1 = char.ToUpper(p1.Name[0]);
            char s2 = char.ToUpper(p2.Name[0]);
            if (s1 > s2)
                return 1;
            if (s1 < s2)
                return -1;
            return 0;
        }
    }

    class PeopleAgeComparer : IComparer<Person>
    {
        public int Compare(Person p1, Person p2)
        {
            if (p1.Age > p2.Age)
                return 1;
            else if (p1.Age < p2.Age)
                return -1;
            else
                return 0;
        }
    }

    class Program
    {
        static void test()
        {
            var p = new List<Person>();
            p.Add(new Person("A", 30));
            p.Add(new Person("a", 40));
            p.Add(new Person("ba", 25));
            p.Add(new Person("Aaa", 10));
            p.Add(new Person("mKS", 13));
            p.Add(new Person("BA", 30));
            foreach (var i in p)
                Console.Write(i);
            Console.WriteLine("before sort");
            p.Sort(new PeopleNameComparer());
            foreach (var i in p)
                Console.Write(i);
            Console.WriteLine("Name sort");
            p.Sort(new PeopleAgeComparer());
            foreach (var i in p)
                Console.Write(i);
            Console.WriteLine("Age sort");
        }
        static void Main(string[] args)
        {
            test();
            // Console.WriteLine("Hello World!");
        }
    }
}
