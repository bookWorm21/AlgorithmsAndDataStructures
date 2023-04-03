using System.Runtime.CompilerServices;
using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.NativeCache
{
    [TestClass]
    public class NativeCacheTests
    {
        [TestMethod]
        public void TestHintIncreasing()
        {
            var cache = new NativeCache<int>(5);
            var first = "first";
            var second = "second";
            var third = "third";
            var four = "four";
            var five = "five";
            var six = "six";

            cache.Put(first, 1);
            cache.Put(second, 2);
            cache.Put(third, 3);
            cache.Put(four, 4);
            cache.Put(five, 5);
            
            Assert.AreEqual(1, cache.hints[0]);
            Assert.AreEqual(1, cache.hints[1]);
            Assert.AreEqual(1, cache.hints[2]);
            Assert.AreEqual(1, cache.hints[3]);
            Assert.AreEqual(1, cache.hints[4]);
            
            int thirdIndex = cache.GetKeyIndex(third);
            var thirdValue = cache.Get(third);

            Assert.AreEqual(3, thirdValue);
            Assert.AreEqual(2, cache.hints[thirdIndex]);
            
            cache.Get(second);
            cache.Get(four);
            cache.Get(five);

            var firstIndex = cache.GetKeyIndex(first);
            cache.Put(six, 6);

            var sixIndex = cache.GetKeyIndex(six);

            Assert.AreEqual(firstIndex, sixIndex);
            Assert.AreEqual(1, cache.hints[firstIndex]);
            Assert.AreEqual(6, cache.Get(six));
        }
    }
}