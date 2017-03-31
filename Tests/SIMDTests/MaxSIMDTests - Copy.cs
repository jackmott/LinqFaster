using NUnit.Framework;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class MaxSIMDTests
    {

        [Test]
        public void MaxSIMDInts()
        {
            var a = Program.intArray.MaxS();
            var b = Program.intArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDLongs()
        {
            var a = Program.longArray.MaxS();
            var b = Program.longArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxSIMDDoubles()
        {
            var a = Program.doubleArray.MaxS();
            var b = Program.doubleArray.Max();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}