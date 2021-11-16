using System;
using System.Reflection;

namespace task1
{
    public class BlackBox
    {
        private int innerValue;
        private BlackBox(int innerValue)
        {
            this.innerValue = innerValue;
        }
        private BlackBox()
        {
            this.innerValue = 0;
        }
        private void Add(int addend)
        {
            this.innerValue += addend;
        }
        private void Subtract(int subtrahend)
        {
            this.innerValue -= subtrahend;
        }
        private void Multiply(int multiplier)
        {
            this.innerValue *= multiplier;
        }
        private void Divide(int divider)
        {
            this.innerValue /= divider;
        }
    }

    class Program
    {
        public static void Exec(Type type, object obj, string func, int val)
        {
            MethodInfo method = type.GetMethod(func, BindingFlags.Instance | BindingFlags.NonPublic);
            method.Invoke(obj, new object[] { val });
            var value = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine(value.GetValue(obj));
        }

        public static void Main()
        {
            Type bbType = Type.GetType("task1.BlackBox");

            ConstructorInfo bbConstructor = bbType.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
            var bbObj = bbConstructor.Invoke(new object[] { });

            while(true)
            {
                string s = Console.ReadLine();
                var command = s.Split(' ');
                try
                {
                    Exec(bbType, bbObj, command[0], Convert.ToInt32(command[1]));
                }
                catch
                {
                    if (command[0] == "Exit")
                        break;
                    Console.WriteLine("Invalid function ar argument, usage: Add 100");
                }

            }
        }

    }
}
