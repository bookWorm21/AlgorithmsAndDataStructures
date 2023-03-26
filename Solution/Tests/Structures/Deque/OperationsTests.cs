using AlgorithmsDataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Deque
{
    [TestClass]
    public class OperationsTests
    {
        [TestMethod]
        public void IsPalindrome_Check()
        {
            Assert.IsFalse(Operations.IsPalindrome("It is just test string"));

            Assert.IsTrue(Operations.IsPalindrome("Лёша на полке клопа нашёл"));
            Assert.IsTrue(Operations.IsPalindrome("Молебен о коне белом"));
            Assert.IsTrue(Operations.IsPalindrome("level"));
            Assert.IsTrue(Operations.IsPalindrome("Do geese see God"));
            Assert.IsTrue(Operations.IsPalindrome("\"Not New York\", – Roy went on"));
        }
    }
}