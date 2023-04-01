using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.NativeDictionary
{
    [TestClass]
    public class NativeDictionaryTests
    {
        [TestMethod]
        public void HashFun_SameString_SameHash()
        {
            var dictionary = new NativeDictionary<string>(19);
            var s1 = "hello, my!";
            var s2 = "hello, my!";
            Assert.IsTrue(dictionary.HashFun(s1) == dictionary.HashFun(s2));
        }

        [TestMethod]
        public void HashFun_StringsWithBitDifferent_DifferentHash()
        {
            var dictionary = new NativeDictionary<string>(19);
            var s1 = "hello, my name is Andrew!";
            var s2 = "hello, my name's Andrew!";
            Assert.IsFalse(dictionary.HashFun(s1) == dictionary.HashFun(s2));
        }

        [TestMethod]
        public void HashFun_StringWithGreatlyDifferent_DifferentHash()
        {
            var dictionary = new NativeDictionary<string>(19);
            var s1 = "hello, hello, hi-pi";
            var s2 = "it is beautiful life, oooo-oooo, hello";
            Assert.IsFalse(dictionary.HashFun(s1) == dictionary.HashFun(s2));
        }

        [TestMethod]
        public void Get_EmptyDictionary_DefaultValue()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var actual = dictionary.Get(key);
            string exptected = null;

            Assert.AreEqual(actual, exptected);
        }

        [TestMethod]
        public void Get_BusySlot_BusySlotValue()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var value = "needed string";
            var hash = dictionary.HashFun(key);
            dictionary.slots[hash] = key;
            dictionary.values[hash] = value;

            var actual = dictionary.Get(key);

            Assert.AreEqual(value, actual);
        }

        [TestMethod]
        public void Get_OnHaveCollision_UnSuccessValue()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var value = "needed string";
            var hash = dictionary.HashFun(key);
            dictionary.slots[hash] = "some busy slot";
            dictionary.values[hash] = "other value";

            string expected = null;
            var actual = dictionary.Get(key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Put_EmptyDictionary_CorrectValue()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var value = "needed string";

            dictionary.Put(key, value);

            var actual = dictionary.Get(key);

            Assert.AreEqual(value, actual);
        }
        
        [TestMethod]
        public void Put_OnBusySlot_CorrectValue()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var expected = "needed string";
            var oldKey = "old key";
            var old = "it is old string";
            var hashIndex = dictionary.HashFun(key);

            dictionary.slots[hashIndex] = oldKey;
            dictionary.values[hashIndex] = old;
            
            dictionary.Put(key, expected);
            var actual = dictionary.Get(key);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(oldKey, dictionary.slots[hashIndex]);
            Assert.AreEqual(key, dictionary.slots[(hashIndex + NativeDictionary<string>.Step) % dictionary.size]);
        }

        [TestMethod]
        public void IsKey_EmptyDictionary_False()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var actual = dictionary.IsKey(key);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsKey_BusySlot_True()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            dictionary.Put(key, "some string");
            bool expected = true;
            bool actual = dictionary.IsKey(key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsKey_BusySlotOnCollision_True()
        {
            var dictionary = new NativeDictionary<string>(19);
            var key = "hello my friend";
            var value = "new string";
            var hashIndex = dictionary.HashFun(key);
            dictionary.slots[hashIndex] = "busy slot";
            dictionary.Put(key, value);

            bool expected = true;
            bool actual = dictionary.IsKey(key);

            Assert.AreEqual(expected, actual);
        }
    }
}