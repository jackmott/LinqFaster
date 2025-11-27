using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class SkipTests
    {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(Test.TEST_SIZE)]
        public void SkipArray(int count)
        {
            int[] a = intArray.SkipF(count);
            IEnumerable<int> b = intArray.Skip(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SkipWhileArray()
        {
            int[] a = intArray.SkipWhileF(onlyEvenInts);
            IEnumerable<int> b = intArray.SkipWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(Test.TEST_SIZE)]
        public void SkipList(int count)
        {
            List<int> a = intList.SkipF(count);
            IEnumerable<int> b = intList.Skip(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SkipWhileList()
        {
            List<int> a = intList.SkipWhileF(onlyEvenInts);
            IEnumerable<int> b = intList.SkipWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }


    }
}
