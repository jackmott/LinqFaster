using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereSumTests
    {
        [Test]
        public  void WhereSumArray()
        {
            var a = intArray.WhereSumF(x => x % 2 == 0);
            var b = intArray.Where(x=>x%2==0).Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = floatArray.WhereSumF(x => x > 0.0f);
            var d = floatArray.Where(x => x > 0.0f).Sum();

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSumArraySelector() {
            var a = intArray.WhereSumF(x => x % 2 == 0,x=>x+1);
            var b = intArray.Where(x => x % 2 == 0).Sum(x=>x+1);

            Assert.That(a, Is.EqualTo(b));

            var c = floatArray.WhereSumF(x => x > 0.0f,x => x / 2.0f);
            var d = floatArray.Where(x => x > 0.0f).Sum(x => x/2.0f);

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSumList()
        {
            var a = intList.WhereSumF(x => x % 2 == 0);
            var b = intList.Where(x => x % 2 == 0).Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = floatList.WhereSumF(x => x > 0.0f);
            var d = floatList.Where(x => x > 0.0f).Sum();

            Assert.That(c, Is.EqualTo(d));
        }

        [Test]
        public void WhereSumListSelector() {
            var a = intList.WhereSumF(x => x % 2 == 0, x => x + 1);
            var b = intList.Where(x => x % 2 == 0).Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));

            var c = floatList.WhereSumF(x => x > 0.0f, x => x / 2.0f);
            var d = floatList.Where(x => x > 0.0f).Sum(x => x / 2.0f);

            Assert.That(c, Is.EqualTo(d));
        }

    }
}
