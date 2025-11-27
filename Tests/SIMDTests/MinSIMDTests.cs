using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class MinSIMDTests
    {

        [Test]
        public void MinSIMDLongs()
        { 
            long a = Test.longArray.MinS();
            long b = Test.longArray.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MinSIMDFloats()
        {
            float a = Test.floatArray.MinS();
            float b = Test.floatArray.Min();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}