using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string [] slots;
        public T [] values;
        public const int Step = 3;

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
            if (key == null)
            {
                return false;
            }
            
            int hashIndex = HashFun(key);
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hashIndex] == null)
                {
                    return false;
                }
                
                if (slots[hashIndex] == key)
                {
                    return true;
                }
                    
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            return slots[hashIndex] != null;
        }

        public void Put(string key, T value)
        {
            if (key == null)
            {
                return;
            }
            
            int hashIndex = HashFun(key);
            int startIndex = hashIndex;
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hashIndex] == null)
                {
                    slots[hashIndex] = key;
                    values[hashIndex] = value;
                }
                
                if (slots[hashIndex] == key)
                {
                    values[hashIndex] = value;
                    return;
                }
                
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            
            slots[startIndex] = key;
            values[startIndex] = value;
        }

        public T Get(string key)
        {
            int hashIndex = HashFun(key);
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hashIndex] == null)
                {
                    return default;
                }
                
                if (slots[hashIndex] == key)
                {
                    return values[hashIndex];
                }
                
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            
            return default;
        }
    } 
}