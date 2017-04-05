using System.Linq;
using JM.LinqFaster;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class RepeatTests
    {
        [Test]
        public void RepeatArray() {
            var a = LinqFaster.RepeatArrayF(2.0f, 10);
            var b = Enumerable.Repeat(2.0f, 10).ToList();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RepeatList()
        {
            var a = LinqFaster.RepeatListF(2.0f, 10);
            var b = Enumerable.Repeat(2.0f, 10).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
