using System;
using System.Linq;
using System.Text;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.PowerSet
{
    [TestClass]
    public class PowerSetTests
    {
        [TestMethod]
        public void Put_EmptySet_AddingElement()
        {
            var expectedSet = new PowerSet<string>("new string");
            var set = new PowerSet<string>();
            set.Put("new string");
            var expectedSize = 1;

            Assert.AreEqual(expectedSize, set.Size());
            Assert.IsTrue(CheckSetsIdentity(expectedSet, set));
        }

        [TestMethod]
        public void Put_DifferentValues_IncreasingSize()
        {
            var first = "first string";
            var second = "second string";
            var expectedSet = new PowerSet<string>(first, second);
            var set = new PowerSet<string>();
            set.Put(first);
            set.Put(second);
            var expectedSize = 2;

            Assert.AreEqual(expectedSize, set.Size());
            Assert.IsTrue(CheckSetsIdentity(expectedSet, set));
        }

        [TestMethod]
        public void Put_SameValues_NotChangingSet()
        {
            var first = "first string";
            var second = first;
            var expectedSet = new PowerSet<string>(first);
            var set = new PowerSet<string>();
            set.Put(first);
            set.Put(second);
            var expectedSize = 1;

            Assert.AreEqual(expectedSize, set.Size());
            Assert.IsTrue(CheckSetsIdentity(expectedSet, set));
        }

        [TestMethod]
        public void Get_EmptySet_False()
        {
            var set = new PowerSet<string>();
            var actual = set.Get("some string");
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Get_AfterAdding_True()
        {
            var set = new PowerSet<string>();
            var adding = "some string";
            set.Put(adding);
            var actual = set.Get(adding);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_EmptySet_False()
        {
            var set = new PowerSet<string>();
            var adding = "some string";
            var actual = set.Remove(adding);
            var expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Remove_ValueWhichAdding_TrueAndCorrectSet()
        {
            var adding = "some string";
            var set = new PowerSet<string>(adding, "s1", "s2", "some string", "hello my friend");
            var expectedSet = new PowerSet<string>("s1", "s2", "hello my friend");
            var expectedResult = true;
            var actual = set.Remove(adding);

            Assert.AreEqual(expectedResult, actual);
            Assert.IsTrue(CheckSetsIdentity(expectedSet, set));
        }

        [TestMethod]
        public void Intersection_WithoutIntersectedPart_EmptySet()
        {
            var first = new PowerSet<string>("first", "second", "third");
            var second = new PowerSet<string>("four", "five", "six");
            var expected = new PowerSet<string>();
            var actual = first.Intersection(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Intersection_SeveralIntersected_SetWithIntersectValues()
        {
            var first = new PowerSet<string>("first", "second", "third", "four");
            var second = new PowerSet<string>("third", "four", "five", "six");
            var expected = new PowerSet<string>("third", "four");
            var actual = first.Intersection(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Intersection_AllSetInIntersection_SetWhichIncludedAllElements()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var second = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var expected = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var actual = first.Intersection(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Union_WithoutIntersectPart_SetWhichIncludedAllElements()
        {
            var first = new PowerSet<string>("first", "second", "third");
            var second = new PowerSet<string>("four", "five", "six");
            var expected = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var actual = first.Union(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Union_SeveralIntersected_SetWhichIncludedAllElements()
        {
            var first = new PowerSet<string>("first", "second", "third", "four");
            var second = new PowerSet<string>("third", "four", "five", "six");
            var expected = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var actual = first.Union(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Union_AllSetInIntersected_AllSetsElements()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var second = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var expected = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var actual = first.Union(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Union_OneOfSetEmpty_FirstSet()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var second = new PowerSet<string>();
            var actual = first.Union(second);

            Assert.IsTrue(CheckSetsIdentity(first, actual));
        }

        [TestMethod]
        public void Difference_WithoutIntersectPart_FirstSet()
        {
            var first = new PowerSet<string>("first", "second", "third");
            var second = new PowerSet<string>("four", "five", "six");
            var actual = first.Difference(second);

            Assert.IsTrue(CheckSetsIdentity(first, actual));
        }

        [TestMethod]
        public void Difference_SeveralIntersected_CorrectSet()
        {
            var first = new PowerSet<string>("first", "second", "third", "four");
            var second = new PowerSet<string>("third", "four", "five", "six");
            var expected = new PowerSet<string>("first", "second");
            var actual = first.Difference(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }
        
        [TestMethod]
        public void Difference_AllSetInIntersected_AllSetsElements()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var second = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var expected = new PowerSet<string>();
            var actual = first.Difference(second);

            Assert.IsTrue(CheckSetsIdentity(expected, actual));
        }

        [TestMethod]
        public void Subset_AllSecondElementsPresentOnFirst_True()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six", "seven", "some string");
            var second = new PowerSet<string>("first", "second", "third", "four", "five", "six");
            var expected = true;
            var actual = first.IsSubset(second);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subset_SecondSetIsEmpty_True()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five", "six", "seven", "some string");
            var second = new PowerSet<string>();
            var actual = first.IsSubset(second);
            var expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Subset_AllFirstElementsPresentOnSecond_False()
        {
            var first = new PowerSet<string>("first", "second", "third", "four", "five");
            var second = new PowerSet<string>("first", "second", "third", "four", "five", "six", "seven", "some string");
            var actual = first.IsSubset(second);
            var expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSpeedIntersection()
        {
            var rand = new Random();
            var first = new PowerSet<string>();
            var second = new PowerSet<string>();
            var elementCount = 20000;
            for (int i = 0; i < elementCount; ++i)
            {
                var size = rand.Next(100, 150);
                var element = new StringBuilder(size);
                for (int j = 0; j < size; ++j)
                {
                    var symbol = (char)rand.Next(char.MinValue, char.MaxValue);
                    element.Append(symbol);
                }

                first.Put(element.ToString());
            }
            
            for (int i = 0; i < elementCount; ++i)
            {
                var size = rand.Next(100, 150);
                var element = new StringBuilder(size);
                for (int j = 0; j < size; ++j)
                {
                    var symbol = (char)rand.Next(char.MinValue, char.MaxValue);
                    element.Append(symbol);
                }

                second.Put(element.ToString());
            }

            var stopWatch = System.Diagnostics.Stopwatch.StartNew();
            var result = first.Intersection(second);
            stopWatch.Stop();
            var resultTime = stopWatch.Elapsed;
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(result.Get("some string"));
            }

            Console.WriteLine();
            Console.WriteLine(resultTime);
        }

        private bool CheckSetsIdentity<T>(PowerSet<T> first, PowerSet<T> second)
        {
            return first.GetEnumerable().OrderBy(arg => arg)
                .SequenceEqual(second.GetEnumerable().OrderBy(arg => arg));
        }
    }
}