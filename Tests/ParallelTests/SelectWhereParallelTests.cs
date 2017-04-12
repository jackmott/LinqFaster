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
            var a = intArray.SelectWhereP(squaredInts, onlyEvenInts);
            var b = intArray.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectWhereP((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intArray.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelSelectWhereList()
        {
            var a = intList.SelectWhereP(squaredInts, onlyEvenInts);
            var b = intList.Select(squaredInts).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectWhereP((x, i) => x + i, (x, i) => x % 2 == 0);
            b = intList.Select((x, i) => x + i).Where(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}

