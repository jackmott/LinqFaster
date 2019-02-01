using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class TakeTests {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(TEST_SIZE)]
        public void TakeArray(int count) {

            var a = intArray.TakeF(count);
            var aSpan = intArray.AsSpan().TakeF(count);
            var b = intArray.Take(count);

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }

        [Test]
        public void TakeWhileArray() {
            var a = intArray.TakeWhileF(onlyEvenInts);
            var aSpan = intArray.AsSpan().TakeWhileF(onlyEvenInts);
            var b = intArray.TakeWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }


        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(TEST_SIZE)]
        public void TakeList(int count) {

            var a = intList.TakeF(count);
            var b = intList.Take(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void TakeWhileList() {
            var a = intList.TakeWhileF(onlyEvenInts);
            var b = intList.TakeWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }



    }
}
