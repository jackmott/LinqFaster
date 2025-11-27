using System;
using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;
using JM.LinqFasterSpan;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class TakeTests
    {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(TEST_SIZE)]
        public void TakeArray(int count)
        {

            int[] a = intArray.TakeF(count);
            int[] aSpan = intArray.AsSpan().TakeF(count);
            IEnumerable<int> b = intArray.Take(count);

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }

        [Test]
        public void TakeWhileArray()
        {
            int[] a = intArray.TakeWhileF(onlyEvenInts);
            int[] aSpan = intArray.AsSpan().TakeWhileF(onlyEvenInts);
            IEnumerable<int> b = intArray.TakeWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }


        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(TEST_SIZE)]
        public void TakeList(int count)
        {

            List<int> a = intList.TakeF(count);
            IEnumerable<int> b = intList.Take(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void TakeWhileList()
        {
            List<int> a = intList.TakeWhileF(onlyEvenInts);
            IEnumerable<int> b = intList.TakeWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }



    }
}
