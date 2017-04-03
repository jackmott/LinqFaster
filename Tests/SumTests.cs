using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class SumTests
    {
        [Test]
        public  void SumArray()
        {
            var a = intArray.SumF();
            var b = intArray.Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = floatArray.SumF();
            var d = floatArray.Sum();

            Assert.That(c, Is.EqualTo(d));

            var e = decimalArray.SumF();
            var f = decimalArray.Sum();

            Assert.That(e, Is.EqualTo(f));
        }

        [Test]
        public void SumList()
        {
            var a = intList.SumF();
            var b = intList.Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = floatList.SumF();
            var d = floatList.Sum();

            Assert.That(c, Is.EqualTo(d));

            var e = decimalList.SumF();
            var f = decimalList.Sum();

            Assert.That(e, Is.EqualTo(f));
        }

    }
}
