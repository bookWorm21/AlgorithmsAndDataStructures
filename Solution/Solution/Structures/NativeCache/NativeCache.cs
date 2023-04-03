using System;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string [] slots;
        public T [] values;
        public int[] hints;
        public const int Step = 1;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hints = new int[size];

            for (int i = 0; i < size; ++i)
            {
                slots[i] = null;
                values[i] = default;
                hints[i] = default;
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
            
            return false;
        }

        public void Put(string key, T value)
        {
            if (key == null)
            {
                return;
            }
            
            int hashIndex = HashFun(key);
            int stepScale = 0;
            int minHint = Int32.MaxValue;
            int minIndex = -1;

            while (stepScale < size)
            {
                if (slots[hashIndex] == null)
                {
                    slots[hashIndex] = key;
                    values[hashIndex] = value;
                    hints[hashIndex] = 1;
                    return;
                }
                
                if (slots[hashIndex] == key)
                {
                    values[hashIndex] = value;
                    hints[hashIndex] = 1;
                    return;
                }

                if (hints[hashIndex] < minHint)
                {
                    minHint = hints[hashIndex];
                    minIndex = hashIndex;
                }
                
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            
            slots[minIndex] = key;
            values[minIndex] = value;
            hints[minIndex] = 1;
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
                    hints[hashIndex] += 1;
                    return values[hashIndex];
                }
                
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            
            return default;
        }

        public int GetKeyIndex(string key)
        {
            int hashIndex = HashFun(key);
            int stepScale = 0;
            while (stepScale < size)
            {
                if (slots[hashIndex] == null)
                {
                    return -1;
                }
                
                if (slots[hashIndex] == key)
                {
                    return hashIndex;
                }
                
                hashIndex += Step;
                hashIndex %= size;
                stepScale += Step;
            }
            
            return -1;
        }
    }
}