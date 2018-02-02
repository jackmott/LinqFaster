using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    class SumSIMDTests
    {

        [Test]
        public void SumSIMDInts()
        {
            var a = Test.intArray.Sum();
            var b = Test.intArray.SumS();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SumSIMDFloats()
        {
            var a = Test.floatArray.Sum();
            var b = Test.floatArray.SumS();
            double diff = Math.Abs(a - b);
            Assert.That(diff, Is.LessThan(0.1));
        }


        [Test]
        public void SumBySIMDFloats()
        {
            var a = Test.floatArray.Sum(x => x * x);
            var b = Test.floatArray.SumS(x => x * x);
            double diff = Math.Abs(a - b);
            Assert.That(diff, Is.LessThan(0.15));

        }

    }
}
