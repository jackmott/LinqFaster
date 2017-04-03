using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class MaxSIMDTests
    {

        [Test]
        public void MaxSIMDInts()
        {
            var a = Test.intArray.MaxS();
            var b = Test.intArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDLongs()
        {
            var a = Test.longArray.MaxS();
            var b = Test.longArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDDoubles()
        {
            var a = Test.doubleArray.MaxS();
            var b = Test.doubleArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}