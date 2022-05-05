using System;
using System.Collections;
using System.Collections.Generic;

namespace task3
{
    class MyLinkedList<T> : IEnumerable<T>
    {
        internal class Node
        {
            internal T val;
            internal Node next;

            public Node(T val)
            {
                this.val = val;
                next = null;
            }
        }

        internal Node head;

        // use auto property instead
        int count = 0;
        public int Count { get { return count; } }

        public void Add(T val)
        {
            Node newNode = new Node(val);
            if (head == null)
            {
                head = newNode;
                count++;
                return;
            }
            Node cur = head;
            while (cur.next != null)
            {
                cur = cur.next;
            }
            cur.next = newNode;
            count++;
        }

        public bool Remove(T val)
        {
            if (head == null)
                return false;
            if (head.val.Equals(val))
            {
                head.val = default(T);
                head = head.next;
                count--;
                return true;
            }
            var cur = head;
            while (cur.next != null)
            {
                if (cur.next.val.Equals(val))
                {
                    cur.next.val = default(T);
                    cur.next = cur.next.next;
                    count--;
                    return true;
                }
                cur = cur.next;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator(head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        class MyEnumerator : IEnumerator<T>
        {
            private Node head = new Node(default(T));
            private Node cur = null;

            public MyEnumerator(Node head)
            {
                this.head.next = head;
                cur = this.head;
            }

            public T Current
            {
                get
                {
                    if (cur == null)
                        throw new InvalidOperationException();
                    return cur.val;
                }
            }

            object System.Collections.IEnumerator.Current => throw new NotImplementedException();

            public bool MoveNext()
            {
                // лучше избавиться от else и сократить тело метода MoveNext(). например, так:
/*
                if (cur == null || cur.next == null)
                    return false;

                cur = cur.next;
                return true;
*/
                if (cur != null && cur.next != null)
                {
                    cur = cur.next;
                    return true;
                }
                else
                    return false;
            }

            public void Reset()
            {
                cur = head;
            }

            public void Dispose() { }
        }
    }

    class Program
    {
        static void print(MyLinkedList<int> l)
        {
            foreach (var i in l)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        static void test()
        {
            var l = new MyLinkedList<int>();
            l.Add(1);
            l.Add(2);
            l.Add(2);
            l.Add(3);
            print(l);

            l.Remove(2);
            print(l);

            l.Remove(2);
            print(l);

            l.Remove(2);
            print(l);

            l.Add(3);
            print(l);
        }

        static void Main(string[] args)
        {
            test();
            // Console.WriteLine("Hello World!");
        }
    }
}
