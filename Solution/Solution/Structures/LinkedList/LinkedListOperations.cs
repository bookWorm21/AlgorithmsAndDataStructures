namespace AlgorithmsDataStructures
{
    public static class LinkedListOperations
    {
        public static LinkedList Sum(LinkedList first, LinkedList second)
        {
            if (first.Count() != second.Count())
            {
                return null;
            }

            LinkedList result = new LinkedList();

            var firstNode = first.head;
            var secondNode = second.head;
            while (firstNode != null)
            {
                result.AddInTail(new Node(firstNode.value + secondNode.value));
                firstNode = firstNode.next;
                secondNode = secondNode.next;
            }
            
            return result;
        }
    }
}