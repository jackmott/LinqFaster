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
            int[] intArray2 = (int[])intArray.Clone();
            bool a = LinqFasterParallel.SequenceEqualP(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray() {
            int[] intArray2 = (int[])intArray.Clone();
            intArray2[3] = -10;
            bool a = LinqFasterParallel.SequenceEqualP(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualList() {
            List<int> intList2 = intList.ToList();
            bool a = LinqFasterParallel.SequenceEqualP(intList, intList2);
            bool b = Enumerable.SequenceEqual(intList, intList2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualList() {
            List<int> testList = intList.ToList();
            testList[3] = -10;
            bool a = LinqFasterParallel.SequenceEqualP(intList, testList);
            bool b = Enumerable.SequenceEqual(intList, testList);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualListAndArray() {
            bool a = LinqFasterParallel.SequenceEqualP(intList, intArray);
            bool b = Enumerable.SequenceEqual(intList, intArray);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualListAndArray() {
            List<int> testList = new List<int>();
            int[] testArray = { 1, 2, 3, 4, };
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            bool a = LinqFasterParallel.SequenceEqualP(intArray, testList);
            bool b = Enumerable.SequenceEqual(intArray, testList);

            Assert.That(a, Is.EqualTo(b));
        }




    }
}
