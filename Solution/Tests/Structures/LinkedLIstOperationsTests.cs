using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LinkedLIstOperationsTests
    {
        [TestMethod]
        public void Sum_ListsWithNotEqualCounts_Null()
        {
            LinkedList first = new LinkedList(5, 3, 7);
            LinkedList second = new LinkedList(5, 3);
            LinkedList expected = null;
            var actual = LinkedListOperations.Sum(first, second);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sum_ListsWithEqualCounts_CorrectResult()
        {
            LinkedList first = new LinkedList(5, 3, 7);
            LinkedList second = new LinkedList(5, 3, 7);
            LinkedList expected = new LinkedList(10, 6, 14);
            var actual = LinkedListOperations.Sum(first, second);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void Sum_TwoEmptyList_EmptyList()
        {
            LinkedList first = new LinkedList();
            LinkedList second = new LinkedList();
            LinkedList expected = new LinkedList();
            var actual = LinkedListOperations.Sum(first, second);

            Assert.IsTrue(expected == actual);
        }
    }
}