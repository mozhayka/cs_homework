using System;
using System.Threading;

namespace task4
{
    class Sudoku
    {
        int[][] numbers;
        private bool isRight = true;
        public Sudoku(int[][] numbers)
        {
            this.numbers = numbers;
        }

        public bool IsSolvable()
        {
            var threads = new Thread[27];
            for (int type = 1; type < 4; type++)
            {
                for (int num = 0; num < 9; num++)
                {
                    int t = type;
                    int n = num;
                    threads[(type - 1) * 9 + num] = new Thread(() => IsSolvable(t, n));
                    threads[(type - 1) * 9 + num].Start();
                }
            }

            foreach (var thr in threads)
                thr.Join();

            return isRight;
        }

        private void IsSolvable(int type, int num)
        {
            if (type == 1)
            {
                var column = numbers[num];
                isRight &= IsOk(column);
            }

            if (type == 2)
            {
                var str = new int[9];
                for (int i = 0; i < 9; i++)
                {
                    str[i] = numbers[i][num];
                }
                isRight &= IsOk(str);
            }

            if (type == 3)
            {
                var sqr = new int[9];
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        sqr[3 * i + j] = numbers[num % 3 + i][num / 3 + j];
                isRight &= IsOk(sqr);
            }
        }

        private bool IsOk(int[] nums)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = i + 1; j < 9; j++)
                {
                    if (nums[i] == nums[j] && nums[i] != -1)
                        return false;
                }
            }

            return true;
        }
    }

    class Program
    {
        static void Test1()
        {
            var n = new int[9][];
            for (int i = 0; i < 9; i++)
            {
                n[i] = new int[9];
                for (int j = 0; j < 9; j++)
                    n[i][j] = -1;
            }
            var sudoku1 = new Sudoku(n);
            Console.WriteLine(sudoku1.IsSolvable());

            n[1][1] = 2;
            var sudoku2 = new Sudoku(n);
            Console.WriteLine(sudoku1.IsSolvable());

            n[1][2] = 2;
            var sudoku3 = new Sudoku(n);
            Console.WriteLine(sudoku1.IsSolvable());
        }

        static void Main(string[] args)
        {
            Test1();
        }
    }
}
