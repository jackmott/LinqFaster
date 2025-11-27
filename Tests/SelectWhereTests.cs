using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class SelectWhereTests
    {
        [Test]
        public void SelectWhereArray()
        {
            int[] a = intArray.SelectWhereF(squaredInts, onlyEvenInts);
            IEnumerable<int> b = intArray.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectWhereF((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intArray.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectWhereList()
        {
            List<int> a = intList.SelectWhereF(squaredInts, onlyEvenInts);
            IEnumerable<int> b = intList.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectWhereF((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intList.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
