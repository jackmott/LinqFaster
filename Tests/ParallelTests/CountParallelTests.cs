using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class CountParallel
    {
        [Test]
        public void ParallelCountArray()
        {
            var a = intArray.CountP(onlyEvenInts);
            var b = intArray.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void ParallelCountList()
        {
            var a = intList.CountP(onlyEvenInts);
            var b = intList.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
