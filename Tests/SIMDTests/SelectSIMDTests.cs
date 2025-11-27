using System.Linq;

using JM.LinqFaster.SIMD;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class SelectSIMDTests
    {

        [Test]
        public void SelectSIMD()
        {
            int[] a = Test.intArray.Select(x => x * x).ToArray();
            int[] b = Test.intArray.SelectS(x => x * x);

            Assert.That(a, Is.EqualTo(b));
        }



    }
}