using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class BinaryTree
    {
        public int[] prev { get; private set; }
        public BinaryTree(int[] prev)
        {
            this.prev = prev;
        }
    }
}
