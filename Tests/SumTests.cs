using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class SumTests
    {
        [Test]
        public  void SumArray()
        {
            var a = Program.intArray.SumF();
            var b = Program.intArray.Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = Program.floatArray.SumF();
            var d = Program.floatArray.Sum();

            Assert.That(c, Is.EqualTo(d));

            var e = Program.decimalArray.SumF();
            var f = Program.decimalArray.Sum();

            Assert.That(e, Is.EqualTo(f));
        }

        [Test]
        public void SumList()
        {
            var a = Program.intList.SumF();
            var b = Program.intList.Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = Program.floatList.SumF();
            var d = Program.floatList.Sum();

            Assert.That(c, Is.EqualTo(d));

            var e = Program.decimalList.SumF();
            var f = Program.decimalList.Sum();

            Assert.That(e, Is.EqualTo(f));
        }

    }
}
