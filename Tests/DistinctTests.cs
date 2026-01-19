using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class DistinctTests {

        [Test]
        public void DistinctInPlaceEmptyList()
        {
            var emptyList = new List<int>();

            emptyList.DistinctInPlaceF();
        }

        [Test]
        public void DistinctInPlaceIntegerList()
        {
            var list = new List<int>() { 1, 2, 2, 3, 3, 3 };
            var a = new List<int>(list);
            var b = list.Distinct().ToList();

            a.DistinctInPlaceF();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
