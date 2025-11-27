using System.Collections.Generic;
using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class RepeatSIMDTests
    {

        [Test]
        public void RepeatSIMD()
        {
            double[] a = LinqFasterSIMD.RepeatS(4.0, 1000);
            IEnumerable<double> b = Enumerable.Repeat(4.0, 1000);

            Assert.That(a, Is.EqualTo(b));
        }

      
    }
}