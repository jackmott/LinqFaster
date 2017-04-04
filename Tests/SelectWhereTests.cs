using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class SelectWhereTests
    {
        [Test]
        public void SelectWhereArray()
        {
            var a = intArray.SelectWhereF(squaredInts,onlyEvenInts);
            var b = intArray.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectWhereF((x, i) => x + i, (x,i) => x % 2 == 0);
            b = intArray.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectWhereList() {
            var a = intList.SelectWhereF(squaredInts, onlyEvenInts);
            var b = intList.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectWhereF((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intList.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
