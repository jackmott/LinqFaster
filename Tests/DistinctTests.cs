using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests {
    [TestFixture]
    class DistinctTests {

        [Test]
        public void  distinctAllArray() {
            var a = intArray.DistinctF();
            var b = intArray.Distinct();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void distinctOneArray() {
            string[] testArray = { "abc", "abc", "abc", "abc", };
            var a = testArray.DistinctF();
            var b = testArray.Distinct();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void distinctAllList() {
            var a = intList.DistinctF();
            var b = intList.Distinct();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void distinctOneList() {
            List<string> testList = new List<string>();
            testList.Add("abc");
            testList.Add("abc");
            testList.Add("abc");
            testList.Add("abc");

            var a = testList.DistinctF();
            var b = testList.Distinct();

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
