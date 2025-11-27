using System;
using System.Linq;

using JM.LinqFaster.SIMD;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class SumSIMDTests
    {

        [Test]
        public void SumSIMDInts()
        {
            int a = Test.intArray.Sum();
            int b = Test.intArray.SumS();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SumSIMDFloats()
        {
            float a = Test.floatArray.Sum();
            float b = Test.floatArray.SumS();
            double diff = Math.Abs(a - b);
            Assert.That(diff, Is.LessThan(0.1));
        }


        [Test]
        public void SumBySIMDFloats()
        {
            float a = Test.floatArray.Sum(x => x * x);
            float b = Test.floatArray.SumS(x => x * x);
            double diff = Math.Abs(a - b);
            Assert.That(diff, Is.LessThan(0.15));

        }

    }
}
