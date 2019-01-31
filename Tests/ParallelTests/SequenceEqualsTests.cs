using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests {
    [TestFixture]
    class SequenceEqualsParallelTests {

        [Test]
        public void SequenceEqualArray() {
            var intArray2 = (int[])intArray.Clone();
            var a = LinqFasterParallel.SequenceEqualP(intArray, intArray2);
            var b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray() {
            var intArray2 = (int[])intArray.Clone();
            intArray2[3] = -10;
            var a = LinqFasterParallel.SequenceEqualP(intArray, intArray2);
            var b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualList() {
            var intList2 = intList.ToList();
            var a = LinqFasterParallel.SequenceEqualP(intList, intList2);
            var b = Enumerable.SequenceEqual(intList, intList2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualList() {
            var testList = intList.ToList();
            testList[3] = -10;
            var a = LinqFasterParallel.SequenceEqualP(intList, testList);
            var b = Enumerable.SequenceEqual(intList, testList);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualListAndArray() {
            var a = LinqFasterParallel.SequenceEqualP(intList, intArray);
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

            var a = LinqFasterParallel.SequenceEqualP(intArray, testList);
            var b = Enumerable.SequenceEqual(intArray, testList);

            Assert.That(a, Is.EqualTo(b));
        }




    }
}
