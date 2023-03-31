using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string [] slots;
        public T [] values;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];

            for (int i = 0; i < size; ++i)
            {
                slots[i] = null;
                values[i] = default;
            }
        }

        public int HashFun(string key)
        {
            int hash = 0;
            foreach (var sym in key)
            {
                hash += sym.GetHashCode();
            }
            return hash % size;
        }

        public bool IsKey(string key)
        {
            int hashIndex = HashFun(key);
            return slots[hashIndex] != null;
        }

        public void Put(string key, T value)
        {
            int hashIndex = HashFun(key);
            slots[hashIndex] = key;
            values[hashIndex] = value;
        }

        public T Get(string key)
        {
            int hashIndex = HashFun(key);
            return values[hashIndex];
        }
    } 
}