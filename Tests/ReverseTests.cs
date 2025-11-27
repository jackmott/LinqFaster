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
    internal class ReverseTests
    {

        [Test]
        public void ReverseArray()
        {
            int[] a = intArray.ReverseF();
            int[] aSpan = intArray.AsSpan().ReverseF();
            IEnumerable<int> b = intArray.Reverse();

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }

        [Test]
        public void ReverseList()
        {
            List<int> a = intList.ReverseF();
            List<int> b = intList.Select(x => x).ToList();
            b.Reverse();
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
