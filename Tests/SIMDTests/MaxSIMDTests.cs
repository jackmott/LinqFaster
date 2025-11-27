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
            int a = Test.intArray.MaxS();
            int b = Test.intArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDLongs()
        {
            long a = Test.longArray.MaxS();
            long b = Test.longArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDDoubles()
        {
            double a = Test.doubleArray.MaxS();
            double b = Test.doubleArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}