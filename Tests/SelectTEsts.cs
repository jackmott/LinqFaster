using System;
using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class SelectTests
    {
        [Test]
        public void SelectArray()
        {
            int[] a = intArray.SelectF(x => x * x);
            IEnumerable<int> b = intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));
            int b1 = Array.AsReadOnly(intArray).SumF(x => x * x);

            a = intArray.SelectF((x, i) => x + i);
            b = intArray.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectSumArray()
        {
            int[] a = intArray.SelectF(x => x * x);
            IEnumerable<int> b = intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));
            int b1 = Array.AsReadOnly(intArray).SumF(x => x * x);

            a = intArray.SelectF((x, i) => x + i);
            b = intArray.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectList()
        {
            List<int> a = intList.SelectF(x => x * x);
            List<int> b = intList.Select(x => x * x).ToList();
            Assert.That(a.Count, Is.Not.EqualTo(0));
            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectF((x, i) => x + i);
            b = intList.Select((x, i) => x + i).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
