using System;
using System.Collections.Generic;

namespace task1
{
    class Lake
    {
        private int[] stones;

        public Lake(int[] stones)
        {
            this.stones = stones;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new LakeEnumerator(stones);
        }

        public class LakeEnumerator : IEnumerator<int>
        {
            private int[] stones;
            private int position = -2;
            private int n;

            public LakeEnumerator(int[] stones)
            {
                this.stones = stones;
                n = stones.Length;
            }

            public int Current
            {
                get
                {
                    if (position == -1)
                        throw new InvalidOperationException();
                    return stones[position];
                }
            }

            object System.Collections.IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                // очень много лишних проверок. лучше вынести проверку на четность/нечетность в начало.
//например
/*
                if (position % 2 == 0)
                {
                    if (position + 2 < n)
                    {    
                      position += 2;
                      return true;
                    }
                    if (position + 2 == n)
                    {
                      position++;
                      return true;
                    }
                    ... 
                }   
                else if (position > 1)
                {
                    position -= 2;
                    return true;
                }


*/
                if (position % 2 == 0 && position + 2 < n)
                {
                    position += 2;
                    return true;
                }
                if (position % 2 == 0 && position + 2 == n)
                {
                    position++;
                    return true;
                }
                if (position % 2 == 0 && position + 2 == n + 1)
                {
                    position--;
                    return true;
                }
                if (position % 2 == 1 && position > 1)
                {
                    position -= 2;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                position = 0;
            }

            public void Dispose() { }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new Lake(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var l2 = new Lake(new int[] { 13 , 23 , 1 , -8 , 4 , 9 });
            foreach(var s in l1)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine("");
            foreach (var s in l2)
            {
                Console.Write($"{s} ");
            }
            
        }
    }
}
