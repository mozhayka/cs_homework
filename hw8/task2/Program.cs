using System;
using System.Runtime.ExceptionServices;

namespace task2
{
    class Program
    {
        static void DivByPrev(ref int[] arr)
        {
            int[] arrCopy = new int[arr.Length];
            for(int i = 1; i < arr.Length; i++)
            {
                arrCopy[i] = arr[i];
                if (arr[i - 1] == 0)
                {
                    // если придется делить на 0, то мы возвращаем изначальные значения и кидаем exception
                    ExceptionDispatchInfo disInf = ExceptionDispatchInfo.Capture(new DivideByZeroException($"arr[{i}] = 0"));
                    for (int j = 1; j < i; j++)
                        arr[j] = arrCopy[j];
                    disInf.Throw();
                }
                arr[i] /= arr[i - 1];
            }
        }

        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3 };
            var b = new int[] { 1, 2, 0, 3 };
            try
            {
                DivByPrev(ref a);
                DivByPrev(ref b);
            }
            catch
            {
                Console.WriteLine("b");
                foreach (var i in b)
                    Console.Write($"{i} ");
                Console.WriteLine();
                Console.WriteLine("a");
                foreach (var i in a)
                    Console.Write($"{i} ");
            }
            
        }
    }
}
