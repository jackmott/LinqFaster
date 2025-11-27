using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;

namespace Tests
{
    [TestFixture]
    class SumParallel
    {
        [Test]
        public void ParallelSumArray()
        {
            int a = intArray.SumP();
            int b = intArray.Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = floatArray.SumP();
            float d = floatArray.Sum();

            float diff = Math.Abs(c - d);
            Assert.That(diff, Is.LessThan(0.1));

            decimal e = decimalArray.SumP();
            decimal f = decimalArray.Sum();

            decimal diff2 = Math.Abs(e-f);
            Assert.That(diff2, Is.LessThan(0.1));

            
        }

        [Test]
        public void ParallelSumArraySelector()
        {
            int a = intArray.SumP(x => x + 1);
            int b = intArray.Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));

            float c = floatArray.SumP(squaredFloats);
            float d = floatArray.Sum(squaredFloats);

            float diff = Math.Abs(c - d);
            Assert.That(diff, Is.LessThan(0.1));
            
        }

        [Test]
        public void ParallelSumList()
        {
            int a = intList.SumP();
            int b = intList.Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = floatList.SumP();
            float d = floatList.Sum();

            float diff = Math.Abs(c - d);
            Assert.That(diff, Is.LessThan(0.1));

            decimal e = decimalList.SumP();
            decimal f = decimalList.Sum();

            decimal diff2 = Math.Abs(e - f);
            Assert.That(diff2, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelSumListSelector()
        {
            int a = intList.SumP(x => x + 1);
            int b = intList.Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));

            float c = floatList.SumP(squaredFloats);
            float d = floatList.Sum(squaredFloats);

            float diff = Math.Abs(c - d);
            Assert.That(diff, Is.LessThan(0.1));
            
        }

    }
}
