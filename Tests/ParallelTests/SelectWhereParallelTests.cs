using System.Collections.Generic;
using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class SelectWhereParallel
    {

        [Test]
        public void ParallelSelectWhereArray()
        {
            int[] a = intArray.SelectWhereP(squaredInts, onlyEvenInts);
            IEnumerable<int> b = intArray.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectWhereP((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intArray.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelSelectWhereList()
        {
            List<int> a = intList.SelectWhereP(squaredInts, onlyEvenInts);
            IEnumerable<int> b = intList.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectWhereP((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intList.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}

