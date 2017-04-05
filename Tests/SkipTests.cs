using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class SkipTests {

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(Test.TEST_SIZE)]
        public void SkipArray(int count) {
            var a = intArray.SkipF(count);
            var b = intArray.Skip(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]        
        public void SkipWhileArray() {
            var a = intArray.SkipWhileF(onlyEvenInts);
            var b = intArray.SkipWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(Test.TEST_SIZE)]
        public void SkipList(int count) {
            var a = intList.SkipF(count);
            var b = intList.Skip(count);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SkipWhileList() {
            var a = intList.SkipWhileF(onlyEvenInts);
            var b = intList.SkipWhile(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }


    }
}
