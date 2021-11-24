using System;

namespace task4
{
    // между блоками кода оставляйте пустую строку. это повышает читаемость	
    struct Pair
    {
        // не ленитесь указывать модификаторы доступа ко всем членам, даже если уровень доступа очевиден
        private long seed;
        private int steps;

        public Pair(long seed, int steps)
        {
            this.seed = seed;
            this.steps = steps;
        }

        public override string ToString()
        {
            return $"({seed}, {steps})";
        }
    }

    // все закрытые члены начинайте с маленькой буквы
    class GenPal
    {
        public Pair PalSeq(long palindrome)
        {
            long seed = 1;
            int steps = GenPalBeginningWith(palindrome, seed);

            while (steps == -1)
            {
                seed++;
                steps = GenPalBeginningWith(palindrome, seed);
            }

            return new Pair(seed, steps);
        }

        private int GenPalBeginningWith(long palindrome, long seed)
        {
            int steps = 0;

            while(seed < palindrome)
            {
                seed += ReverseInt(seed);
                steps++;
            }

            if(seed == palindrome)
            {
                return steps;
            }

            return -1;
        }

        private long ReverseInt(long a)
        {
            string s = a.ToString();
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            s = new string(arr);
            return long.Parse(s);
        }
    }

    class Program
    {
        static void PrintPalSeq(long palindrome)
        {   
            var g = new GenPal();
            Console.WriteLine($"{palindrome} -> {g.PalSeq(palindrome)}");
        }
 
       static void Main(string[] args)
        {
            PrintPalSeq(1);
            PrintPalSeq(11);
            PrintPalSeq(4884);
            PrintPalSeq(3113);
            PrintPalSeq(8836886388);

            /* 
             * В примере PalSeq(4884) ➞ (78, 4), но можно начинать с 3
             PALINDROME 4884, SEED 3
                3 + 3
                6 + 6
                12 + 21
                33 + 33
                66 + 66
                132 + 231
                363 + 363
                726 + 627
                1353 + 3531
                (3, 9)
            */
        }
    }
}
