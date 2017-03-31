using NUnit.Framework;
using JM.LinqFaster;
using JM.LinqFaster.SIMD;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class MinSIMDTests
    {

        [Test]
        public void MinSIMDLongs()
        { 
            var a = Program.longArray.MinS();
            var b = Program.longArray.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MinSIMDFloats()
        {
            var a = Program.floatArray.MinS();
            var b = Program.floatArray.Min();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}