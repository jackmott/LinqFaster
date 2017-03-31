using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class RangeTests
    {
        [Test]
        public void RangeArray()
        {
            var a = LinqFaster.RangeArrayF(-100, 200);
            var b = Enumerable.Range(-100, 200).ToArray();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RangeList()
        {
            var a = LinqFaster.RangeListF(-100, 200);
            var b = Enumerable.Range(-100, 200).ToList();

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
