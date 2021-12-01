using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{        
    class Motor
    {
        private bool HasCylinder;
        public int Power { get; private set; }

        public Motor(int power, bool cyl)
        {
            Power = power;
            HasCylinder = cyl;
        }
    }

    class Car
    {
        public int BodyNum { get; private set; }

        private Motor motor;
        // енумераторы и вложенные классы лучше всегда располагать в начале класса
        public enum Gearbox
        {
            auto,
            manual
        }
        // открытые поля - это bad design
        public Gearbox gear;
        public int StereoSistem { get; set; }

        public Car(int bodyNum, int motorPower, bool cyl, Gearbox gear, int stereosistem)
        {
            BodyNum = bodyNum;
            motor = new Motor(motorPower, cyl);
            this.gear = gear;
            stereoSistem = stereosistem;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Car number {BodyNum} with {gear} gearbox");
        }

    }
}
