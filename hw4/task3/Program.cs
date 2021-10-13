using System;

namespace task3
{
    delegate double Func(double x);

    class Integ
    {
        double eps = 0.0001;
        public double Integrate(Func f, double x, double y)
        {
            double sign = 1, ans = 0;
            if(x > y)
            {
                double z = x;
                x = y;
                y = z;
                sign = -1;
            }
            while(x < y)
            {
                ans += f(x) * eps;
                x += eps;
            }
            return ans * sign;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Func lin = (x) => x;
            Func sqr = (x) => x * x;
            var i = new Integ();
            Console.WriteLine(i.Integrate(lin, 0, 2));
            Console.WriteLine(i.Integrate(sqr, 2, 0));
            Console.WriteLine("Hello World!");
        }
    }
}
