using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster.SIMD.Parallel;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class SelectSIMDPTests
    {
        [Test]
        public void SelectSIMDP()
        {
            int[] a = Test.intArray.SelectSP(x => x * x, x => x * x);
            IEnumerable<int> b = Test.intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));


            //            Assert.That(c, Is.EqualTo(d));


            //          Assert.That(e, Is.EqualTo(f));
        }

    }
}
