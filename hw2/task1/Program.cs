using System;
using System.Diagnostics;

namespace task1
{
    class Pair<K, T>
    {
        K key;
        T value;

        public Pair(K key, T value)
        {
            this.key = key;
            this.value = value;
        }

        public K getKey()
        {
            return key;
        }

        public T getVal()
        {
            return value;
        }

        public bool Equals(Pair<K, T> p)
        {
            return key.Equals(p.getKey()) && value.Equals(p.getVal());
        }
    }

    class HashTable<K, T>
    {
        const int maxSize = 10007;
        const int mod = maxSize;
        Pair<K, T>[] table = new Pair<K, T>[maxSize];
        int[] used = new int[maxSize];
        
        private int getHash(K key)
        {
            return (key.GetHashCode() % mod + mod) % mod;
        }

        public void add(K key, T val)
        {
            int hash = getHash(key);
            var p = new Pair<K, T>(key, val);
            while(used[hash] != 0)
            {
                if(table[hash].Equals(p))
                {
                    return;
                }
                hash = (hash + 1) % mod;
            }
            table[hash] = p;
            used[hash] = 1;
        }

        public void delete(K key, T val)
        {
            int hash = getHash(key);
            var p = new Pair<K, T>(key, val);
            while (used[hash] != 0)
            {
                if (table[hash].Equals(p))
                {
                    used[hash] = 2;
                    return;
                }
                hash = (hash + 1) % mod;
            }
        }

        public Pair<K, T> find(K key)
        {
            int hash = getHash(key);
            while(used[hash] != 0)
            {
                if(key.Equals(table[hash].getKey()) && used[hash] == 1)
                {
                    return table[hash];
                }
                hash = (hash + 1) % mod;
            }
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, int> table = new HashTable<string, int>();
            table.add("a", 2);
            table.add("b", 3);
            Debug.Assert(table.find("a").getVal() == 2);
            table.delete("a", 3);
            Debug.Assert(table.find("a").getVal() == 2);
            table.delete("a", 2);
            Debug.Assert(table.find("a") == null);
        }
    }
}
