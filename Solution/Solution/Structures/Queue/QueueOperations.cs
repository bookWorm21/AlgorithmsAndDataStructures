namespace AlgorithmsDataStructures
{
    public static class QueueOperations
    {
        public static void CircleMove<T>(this Queue<T> queue, int stepCount = 1)
        {
            for (int i = 0; i < stepCount; ++i)
            {
                queue.Enqueue(queue.Dequeue());
            }
        }
    }
}