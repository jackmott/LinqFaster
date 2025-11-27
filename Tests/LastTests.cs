using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class LastTests
    {

        [Test]
        public void LastArray()
        {
            int a = intArray.LastF();
            int b = intArray.Last();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastArrayPredicate()
        {
            int a = intArray.LastF(x => x > 0);
            int b = intArray.Last(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastOrDefaultArray()
        {
            int a = intArray.LastOrDefaultF(x => x > 99999);
            int b = intArray.LastOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void LastList()
        {
            int a = intList.LastF();
            int b = intList.Last();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastListPredicate()
        {
            int a = intList.LastF(x => x > 0);
            int b = intList.Last(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastOrDefaultList()
        {
            int a = intList.LastOrDefaultF(x => x > 99999);
            int b = intList.LastOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
