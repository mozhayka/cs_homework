using System;

namespace task1
{
    class Car
    {
        bool is_studded;
        public bool IsStudded { get { return is_studded; } set { is_studded = value; } }
        public enum type
        {
            truck,
            racing,
            passenger
        }
        type model;
        public type Model { get { return model; } set { model = value; } }
        int weight, age;
        public int Weight { get { return weight; } set { weight = value; } }
        public int Age { get { return age; } set { age = value; } }

        public Car(bool is_studded, type model, int weight, int age)
        {
            this.is_studded = is_studded;
            this.model = model;
            this.weight = weight;
            this.age = age;
        }

    }
    class Horse
    {
        bool is_shod;
        public enum breed
        {
            heavy,
            steed,
            common
        }
        breed type;
        int weight, age, height;

        public Horse(bool is_shod, breed type, int weight, int age, int height)
        {
            this.is_shod = is_shod;
            this.type = type;
            this.weight = weight;
            this.age = age;
            this.height = height;
        }

        public static implicit operator Horse(Car car)
        {
            breed type = getBreed(car.Model);
            return new Horse(car.IsStudded, type, car.Weight / 10, car.Age, 200);
        }

        public static explicit operator Car(Horse horse)
        {
            Car.type model = getType(horse.type);
            return new Car(horse.is_shod, model, horse.weight * 10, horse.age);
        }

        public static bool operator >(Horse h1, Horse h2)
        {
            if (h1.age > h2.age)
                return true;
            if (h1.age < h2.age)
                return false;
            if (h1.height > h2.height)
                return true;
            if (h1.height < h2.height)
                return false;
            if (h1.weight > h2.weight)
                return true;
            return false;
        }

        public static bool operator <(Horse h1, Horse h2)
        {
            return h2 > h1;
        }

        public static bool operator ==(Horse h1, Horse h2)
        {
            return !(h2 > h1) && !(h2 < h1);
        }

        public static bool operator !=(Horse h1, Horse h2)
        {
            return !(h1 == h2);
        }

        private static Car.type getType(breed type)
        {
            Car.type model;
            switch (type)
            {
                case breed.common:
                    model = Car.type.passenger;
                    break;
                case breed.steed:
                    model = Car.type.racing;
                    break;
                case breed.heavy:
                    model = Car.type.truck;
                    break;
                default:
                    model = Car.type.passenger;
                    break;
            }
            return model;
        }

        private static breed getBreed(Car.type model)
        {
            breed type;
            switch (model)
            {
                case Car.type.passenger:
                    type = breed.common;
                    break;
                case Car.type.racing:
                    type = breed.steed;
                    break;
                case Car.type.truck:
                    type = breed.heavy;
                    break;
                default:
                    type = breed.common;
                    break;
            }
            return type;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Horse h1 = new Horse(true, Horse.breed.common, 150, 20, 200);
            Car c1 = new Car(false, Car.type.truck, 4000, 5);
            Horse h2 = c1;
            Car c2 = (Car)h1;
            if(h1 > h2)
            {
                Console.WriteLine("h1 > h2");
            }
        }
    }
}
