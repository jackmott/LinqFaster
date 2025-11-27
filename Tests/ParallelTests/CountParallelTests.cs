using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class CountParallel
    {
        [Test]
        public void ParallelCountArray()
        {
            int a = intArray.CountP(onlyEvenInts);
            int b = intArray.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void ParallelCountList()
        {
            int a = intList.CountP(onlyEvenInts);
            int b = intList.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
