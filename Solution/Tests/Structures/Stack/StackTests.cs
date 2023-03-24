using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Stack
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Size_EmptyStack_0()
        {
            var stack = new Stack<int>();
            var expected = 0;
            var actual = stack.Size();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Size_SeveralValuesOnStack_CorrectSize()
        {
            var stack = new Stack<int>();
            var expected = 5;
            for (int i = 0; i < expected; ++i)
            {
                stack.Push(3);
            }
            var actual = stack.Size();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Pop_EmptyStack_DefaultValue()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(default, stack.Pop());
        }

        [TestMethod]
        public void Pop_PushSomeValue_SomeValue()
        {
            var stack = new Stack<int>();
            int value = 5;
            stack.Push(value);
            Assert.AreEqual(value, stack.Pop());
        }

        [TestMethod]
        public void Pop_PushSeveralValue_ValuesOnReverseOrder()
        {
            var stack = new Stack<int>();
            var values = new int[] {5, 3, 7, 8, 9};
            for (int i = 0; i < values.Length; ++i)
            {
                stack.Push(values[i]);
            }

            for (int i = 0; i < values.Length; ++i)
            {
                Assert.AreEqual(values[values.Length - 1 - i], stack.Pop());
            }
        }

        [TestMethod]
        public void Peek_EmptyStack_DefaultValue()
        {
            var stack = new Stack<int>();
            Assert.AreEqual(default, stack.Peek());
        }

        [TestMethod]
        public void Peek_PushSeveralValues_LastPushedValue()
        {
            var stack = new Stack<int>();
            var values = new int[] {5, 3, 7, 8, 9};
            for (int i = 0; i < values.Length; ++i)
            {
                stack.Push(values[i]);
            }

            Assert.AreEqual(values[values.Length - 1], stack.Pop());
        }
    }
}