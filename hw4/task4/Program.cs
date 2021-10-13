using System;
using System.Collections.Generic;

namespace task4
{
    class Hamster : IComparable
    {
        public enum Color
        {
            white,
            grey,
            black
        }

        // названия классов и стрктур лучше всегда начинать с заглавной буквы, даже если это внутренняя закрытая структура
	private struct Wool
        {
            public int fluffiness;
            public wool(int fluffiness)
            {
                this.fluffiness = fluffiness;
            }
        }

        private readonly Random rand = new Random();

        private Color colour;
        private Wool fur;
        private int weight, age, height;

        public Hamster(Color colour, int fluffiness, int weight, int age, int height)
        {
            this.colour = colour;
            this.fur = new wool(fluffiness);
            this.weight = weight;
            this.age = age;
            this.height = height;
        }

        public Hamster()
        {
            colour = getRandomColor();
            fur = new Wool(rand.Next(0, 10));
            weight = rand.Next(1, 10);
            age = rand.Next(0, 5);
            height = rand.Next(10, 20);
        }

        public int CompareTo(object o)
        {
            Hamster h = o as Hamster;
            if (h == null)
                throw new Exception("Uncomparable objects");

            if (fur.fluffiness > h.fur.fluffiness)
                return 1;
            if (fur.fluffiness < h.fur.fluffiness)
                return -1;

            int colorCmp = cmpColor(h);
            if (colorCmp != 0)
                return colorCmp;

            if (weight > h.weight)
                return 1;
            if (weight < h.weight)
                return -1;

            if (age > h.age)
                return 1;
            if (age < h.age)
                return -1;

            if (height > h.height)
                return 1;
            if (height < h.height)
                return -1;

            return 0;
        }

        public override string ToString()
        {
            return $"Hamster fluffiness = {fur.fluffiness}, color = {colour}, weight = {weight}, age = {age}, height = {height}";
        }

        private int cmpColor(Hamster h)
        {
            if(h.colour == colour)
                return 0;
            if (h.colour == Color.white || h.colour == Color.grey && colour == Color.black)
                return -1;
            return 1;
        }

        private Color getRandomColor()
        {
            int color = rand.Next(0, 3);
            switch (color)
            {
                case 0:
                    return Color.white;
                case 1:
                    return Color.grey;
                case 2:
                    return Color.black;
                default:
                    return Color.white;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Hamster>();
            for(int i = 0; i < 10; i++)
            {
                list.Add(new Hamster());
            }

            list.Sort();

            foreach (var i in list)
                Console.WriteLine(i);
        }
    }
}
