using System;
using System.Collections.Generic;
using static task1.Car;

namespace task1
{
    class Program
    {
        static void Test()
        {
            var cars = new List<Car>();
            cars.Add(new ModelA(123, 200, false, 3, true));
            cars.Add(new ModelA(234, 150, true, 2, false));
            cars.Add(new ModelB(777, 3));
            cars.Add(new Car(105, 200, false, Gearbox.auto, 3));
            foreach (var car in cars)
                car.PrintInfo();
        }
        static void Main(string[] args)
        {
            Test();
        }
    }
}
