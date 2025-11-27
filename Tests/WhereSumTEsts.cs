using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class WhereSumTests
    {
        [Test]
        public void WhereSumArray()
        {
            int a = intArray.WhereSumF(x => x % 2 == 0);
            int b = intArray.Where(x => x % 2 == 0).Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = floatArray.WhereSumF(x => x > 0.0f);
            float d = floatArray.Where(x => x > 0.0f).Sum();

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSumArraySelector()
        {
            int a = intArray.WhereSumF(x => x % 2 == 0, x => x + 1);
            int b = intArray.Where(x => x % 2 == 0).Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));

            float c = floatArray.WhereSumF(x => x > 0.0f, x => x / 2.0f);
            float d = floatArray.Where(x => x > 0.0f).Sum(x => x / 2.0f);

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSumList()
        {
            int a = intList.WhereSumF(x => x % 2 == 0);
            int b = intList.Where(x => x % 2 == 0).Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = floatList.WhereSumF(x => x > 0.0f);
            float d = floatList.Where(x => x > 0.0f).Sum();

            Assert.That(c, Is.EqualTo(d));
        }

        [Test]
        public void WhereSumListSelector()
        {
            int a = intList.WhereSumF(x => x % 2 == 0, x => x + 1);
            int b = intList.Where(x => x % 2 == 0).Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));

            float c = floatList.WhereSumF(x => x > 0.0f, x => x / 2.0f);
            float d = floatList.Where(x => x > 0.0f).Sum(x => x / 2.0f);

            Assert.That(c, Is.EqualTo(d));
        }

    }
}
