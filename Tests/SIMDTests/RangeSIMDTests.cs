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
            var a = LinqFasterSIMD.RangeS(-100, 100);
            var b = Enumerable.Range(-100, 100);

            Assert.That(a, Is.EqualTo(b));
        }

      
    }
}