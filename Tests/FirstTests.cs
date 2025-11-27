using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class FirstTests
    {

        [Test]
        public void FirstArray()
        {
            int a = intArray.FirstF();
            int b = intArray.First();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstArrayPredicate()
        {
            int a = intArray.FirstF(x => x > 0);
            int b = intArray.First(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstOrDefaultArray()
        {
            int a = intArray.FirstOrDefaultF(x => x > 99999);
            int b = intArray.FirstOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void FirstList()
        {
            int a = intList.FirstF();
            int b = intList.First();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstListPredicate()
        {
            int a = intList.FirstF(x => x > 0);
            int b = intList.First(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstOrDefaultList()
        {
            int a = intList.FirstOrDefaultF(x => x > 99999);
            int b = intList.FirstOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
