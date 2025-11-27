using System.Collections.Generic;
using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class RangeSIMDTests
    {

        [Test]
        public void RangeSIMD()
        {
            int[] a = LinqFasterSIMD.RangeS(-100, 100);
            IEnumerable<int> b = Enumerable.Range(-100, 100);

            Assert.That(a, Is.EqualTo(b));
        }

      
    }
}