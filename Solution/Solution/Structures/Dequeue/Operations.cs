using System;

namespace AlgorithmsDataStructures
{
    public static class Operations
    {
        public static bool IsPalindrome(string str)
        {
            var deque = new Deque<char>();
            foreach (var symbol in str)
            {
                if (symbol == ' ')
                {
                    continue;
                }
                
                if(char.IsPunctuation(symbol))
                {
                    continue;
                }

                deque.AddTail(char.ToLower(symbol));
            }

            while (deque.Size() > 1)
            {
                if (deque.RemoveFront() != deque.RemoveTail())
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}