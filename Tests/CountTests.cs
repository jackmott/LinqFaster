using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class CountTests
    {

        [Test]
        public void CountArray()
        {
            int a = intArray.CountF(onlyEvenInts);
            int b = intArray.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void CountList()
        {
            int a = intList.CountF(onlyEvenInts);
            int b = intList.Count(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
