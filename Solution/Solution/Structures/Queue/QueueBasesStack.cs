namespace AlgorithmsDataStructures
{
    public class QueueBasesStack<T>
    {
        private readonly Stack<T> _entering;
        private readonly Stack<T> _exiting;
        
        public bool IsEmpty => Size() > 0;

        public QueueBasesStack()
        {
            _entering = new Stack<T>();
            _exiting = new Stack<T>();
        }
        
        public void Enqueue(T item)
        {
            _entering.Push(item);
        }

        public T Dequeue()
        {
            if (_exiting.Size() > 0)
            {
                return _exiting.Pop();
            }

            if (_entering.Size() == 0)
            {
                return default;
            }

            for (int i = 0; i < _entering.Size(); ++i)
            {
                _exiting.Push(_entering.Pop());
            }

            return _exiting.Pop();
        }

        public int Size()
        {
            return _entering.Size() + _exiting.Size();
        }
    }
}