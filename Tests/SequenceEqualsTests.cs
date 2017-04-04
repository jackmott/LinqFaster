using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests {
    [TestFixture]
    class SequenceEqualsTests {

        [Test]
        public void SequenceEqualArray() {
            var a = LinqFaster.SequenceEqualF(intArray, intArray);
            var b = Enumerable.SequenceEqual(intArray, intArray);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray() {
            int[] testArray = { 1, 2, 3, 4, };
            var a = LinqFaster.SequenceEqualF(intArray, testArray);
            var b = Enumerable.SequenceEqual(intArray, testArray);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualList() {
            var a = LinqFaster.SequenceEqualF(intList, intList);
            var b = Enumerable.SequenceEqual(intList, intList);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualList() {
            var testList = new List<int>();
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            var a = LinqFaster.SequenceEqualF(intList, testList);
            var b = Enumerable.SequenceEqual(intList, testList);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualListAndArray() {
            var a = LinqFaster.SequenceEqualF(intList, intArray);
            var b = Enumerable.SequenceEqual(intList, intArray);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualListAndArray() {
            var testList = new List<int>();
            int[] testArray = { 1, 2, 3, 4, };
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            var a = LinqFaster.SequenceEqualF(intArray, testList);
            var b = Enumerable.SequenceEqual(intArray, testList);

            Assert.That(a, Is.EqualTo(b));
        }




    }
}
