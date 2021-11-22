using System;
using System.Diagnostics;
using System.IO;

namespace task2
{
    class Program
    {
        static string Serialize(BinaryTree tree)
        {
            string serialized = "";
            var elem_size = (int)Math.Ceiling(Math.Log2(tree.prev.Length));
            
            for (int i = 0; i < elem_size; i++)
                serialized += '1';
            serialized += '0';

            foreach (var prev in tree.prev)
            {
                int BinaryCode = Convert.ToInt32(Convert.ToString(prev, 2));
                var code = BinaryCode.ToString($"D{elem_size}");
                serialized += code;
            }

            return serialized;
        }

        static BinaryTree Deserialize(string tree)
        {
            int elem_size = 0;

            while (tree[elem_size] == '1')
                elem_size++;

            int n = (tree.Length - 1 - elem_size) / elem_size;
            var prev = new int[n];
            tree = tree.Substring(elem_size + 1);

            for (int i = 0; i < n; i++)
            {
                string leaf = tree.Substring(i * elem_size, elem_size);
                int pre = 0;
                foreach(var c in leaf)
                {
                    pre = pre * 2 + (c - '0');
                }
                prev[i] = pre;
            }

            return new BinaryTree(prev);
        }

        static void Test(int[] prev)
        {
            var tree = new BinaryTree(prev);
            var ser_tree = Serialize(tree);   

            Console.WriteLine(ser_tree);         
            var des_tree = Deserialize(ser_tree);

            for (int i = 0; i < prev.Length; i++)
                Debug.Assert(prev[i] == des_tree.prev[i]);
        }
        static void Main(string[] args)
        {
            Test(new int[] { 0, 0, 1, 2, 3 });
        }
    }
}
