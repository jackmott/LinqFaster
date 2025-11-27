using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class SequenceEqualsTests
    {

        [Test]
        public void SequenceEqualArray()
        {
            int[] intArray2 = (int[])intArray.Clone();
            bool a = LinqFaster.SequenceEqualF(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray()
        {
            int[] intArray2 = (int[])intArray.Clone();
            intArray2[3] = -10;
            bool a = LinqFaster.SequenceEqualF(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualList()
        {
            List<int> intList2 = intList.ToList();
            bool a = LinqFaster.SequenceEqualF(intList, intList2);
            bool b = Enumerable.SequenceEqual(intList, intList2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualList()
        {
            List<int> testList = intList.ToList();
            testList[3] = -10;
            bool a = LinqFaster.SequenceEqualF(intList, testList);
            bool b = Enumerable.SequenceEqual(intList, testList);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceEqualListAndArray()
        {
            bool a = LinqFaster.SequenceEqualF(intList, intArray);
            bool b = Enumerable.SequenceEqual(intList, intArray);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualListAndArray()
        {
            List<int> testList = new List<int>();
            int[] testArray = { 1, 2, 3, 4, };
            testList.Add(1);
            testList.Add(2);
            testList.Add(3);

            bool a = LinqFaster.SequenceEqualF(intArray, testList);
            bool b = Enumerable.SequenceEqual(intArray, testList);

            Assert.That(a, Is.EqualTo(b));
        }




    }
}
