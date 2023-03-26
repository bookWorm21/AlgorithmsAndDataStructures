using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Deque
{
    [TestClass]
    public class DequeTests
    {
        [TestMethod]
        public void AddFront_EmptyDeque_DequeWithThisElement()
        {
            var actual = new Deque<int>();
            var addValue = 5;
            var expected = new Deque<int>(addValue);
            actual.AddFront(addValue);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void AddFront_SomeDeque_AddingElementOnFirst()
        {
            var actual = new Deque<int>(7, 8, 9, 12, 3);
            var addValue = 5;
            actual.AddFront(addValue);
            var expected = new Deque<int>(5, 7, 8, 9, 12, 3);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void AddTail_EmptyDeque_DequeWithThisElement()
        {
            var actual = new Deque<int>();
            var addValue = 5;
            var expected = new Deque<int>(addValue);
            actual.AddFront(addValue);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void AddTail_SomeDeque_AddingElementOnLast()
        {
            var actual = new Deque<int>(7, 8, 9, 12, 3);
            var addValue = 5;
            actual.AddTail(addValue);
            var expected = new Deque<int>(7, 8, 9, 12, 3, 5);

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void RemoveFront_EmptyDeque_DefaultValue()
        {
            var deque = new Deque<int>();
            var expected = default(int);
            var actual = deque.RemoveFront();

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void RemoveFront_SomeDeque_DequeWithoutFirstElement()
        {
            var actual = new Deque<int>(7, 8, 9, 12, 3);
            var expecteRemoved = 7;
            var actualRemoved = actual.RemoveFront();
            var expected = new Deque<int>(8, 9, 12, 3);

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expecteRemoved, actualRemoved);
        }

        [TestMethod]
        public void RemoveTail_EmptyDeque_DefaultValue()
        {
            var deque = new Deque<int>();
            var expected = default(int);
            var actual = deque.RemoveTail();

            Assert.IsTrue(expected == actual);
        }

        [TestMethod]
        public void RemoveTail_SomeDeque_DequeWithoutTailElement()
        {
            var actual = new Deque<int>(7, 8, 9, 12, 3);
            var expecteRemoved = 3;
            var actualRemoved = actual.RemoveTail();
            var expected = new Deque<int>(7, 8, 9, 12);

            Assert.IsTrue(expected == actual);
            Assert.AreEqual(expecteRemoved, actualRemoved);
        }
    }
}