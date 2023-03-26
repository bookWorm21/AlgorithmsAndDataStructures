namespace AlgorithmsDataStructures
{
    public static class QueueOperations
    {
        public static void CircleMove<T>(this Queue<T> queue, int stepCount = 1)
        {
            if (queue.IsEmpty)
            {
                return;
            }
            
            for (int i = 0; i < stepCount; ++i)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}