using System;
using System.Linq;
using System.Reflection;

namespace task2
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    class CustomAttribute : Attribute
    {
        public string Author { get; private set; }
        public int RevisionNumber { get; private set; }
        public string Description { get; private set; }
        public string[] Reviewers { get; private set; }
        public CustomAttribute(string author, int num, string description, params string[] reviewers)
        {
            this.Author = author;
            RevisionNumber = num;
            Description = description;
            Reviewers = reviewers;
        }
    }

    [Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
    public class HealthScore
    {
        [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
        public static long CalcScoreData()
        {
            return 100;
        }

        public void AnotherMethod()
        {

        }

        [Custom("a", 3, "description w/o reviewers")]
        private void PrivateMethod(int i)
        {

        }
    }

    public class Tracker
    {
        private void PrintAttributeInfo(CustomAttribute attribute, string name)
        {
            Console.WriteLine($"{name} is written by {attribute.Author}, \n" +
                    $"revision number {attribute.RevisionNumber} \n" +
                    $"description:\n{attribute.Description}\nreviewers:");
            foreach(var rev in attribute.Reviewers)
            {
                Console.WriteLine(rev);
            }
            Console.WriteLine();
        }
        private void PrintInfo(MethodInfo method)
        {
            if (method.CustomAttributes.Any(a => a.AttributeType == typeof(CustomAttribute)))
            {
                object[] attributes = method.GetCustomAttributes(false)
                    .Where(a => a is CustomAttribute)
                    .Select(a => a)
                    .ToArray();

                foreach (CustomAttribute attribute in attributes)
                {
                    PrintAttributeInfo(attribute, method.Name);
                }
            }
        }

        private void PrintInfo(Type type)
        {
            if (type.CustomAttributes.Any(a => a.AttributeType == typeof(CustomAttribute)))
            {
                object[] attributes = type.GetCustomAttributes(false)
                    .Where(a => a is CustomAttribute)
                    .Select(a => a)
                    .ToArray();

                foreach (CustomAttribute attribute in attributes)
                {
                    PrintAttributeInfo(attribute, type.Name);
                }
            }
        }

        public void PrintMethodsByAuthor()
        {
            Type classType = typeof(HealthScore);
            MethodInfo[] methods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

            PrintInfo(classType);
            foreach (MethodInfo method in methods)
            {
                PrintInfo(method);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
