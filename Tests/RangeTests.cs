using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class RangeTests
    {
        [Test]
        public void RangeArray()
        {
            int[] a = LinqFaster.RangeArrayF(-100, 200);
            int[] b = Enumerable.Range(-100, 200).ToArray();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RangeList()
        {
            List<int> a = LinqFaster.RangeListF(-100, 200);
            List<int> b = Enumerable.Range(-100, 200).ToList();

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
