using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string [] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) 
            {
                slots[i] = null;
            }
        }

        public int HashFun(string value)
        {
            int hash = 0;
            foreach (var sym in value)
            {
                hash += sym.GetHashCode();
            }
            return hash % size;
        }

        public int SeekSlot(string value)
        {
            int slotIndex = HashFun(value);
            if (slots[slotIndex] == null)
            {
                return slotIndex;
            }
            
            int stepScale = 0;
            
            do
            {
                slotIndex += step;
                stepScale += step;
                slotIndex %= size;

                if (slots[slotIndex] == null)
                {
                    return slotIndex;
                }
            } while (stepScale < size);
            
            return -1;
        }

        public int Put(string value)
        {
            int slot = SeekSlot(value);
            if (slot != -1)
            {
                slots[slot] = value;
            }

            return slot;
        }

        public int Find(string value)
        {
            int hashIndex = HashFun(value);
            int stepScale = 0;

            if (slots[hashIndex] == null)
            {
                return -1;
            }
            
            while (stepScale < size)
            {
                if (slots[hashIndex] == value)
                {
                    return hashIndex;
                }
                
                hashIndex += step;
                hashIndex %= size;
                stepScale += step;
            }
            
            return -1;
        }
    }
}