using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class SelectTests
    {
        [Test]
        public void SelectArray()
        {
            var a = intArray.SelectF(x => x * x);
            var b = intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectF((x, i) => x + i);
            b = intArray.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectList()
        {
            var a = intList.SelectF(x => x * x);
            var b = intList.Select(x => x * x).ToList();
            Assert.That(a.Count, Is.Not.EqualTo(0));
            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectF((x, i) => x + i);
            b = intList.Select((x, i) => x + i).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
