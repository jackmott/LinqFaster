using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereAggregateParallel
    {

        [Test]
        public void ParallelWhereAggregateSumArray()
        {
            var a =
                intArray.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x);

            var b = intArray.WhereAggregateP(onlyEvenInts, (acc, x) => acc += x);

            var c = intArray.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void ParallelWhereAggregateSelectorArray()
        {
            var a =
                intArray.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            var b = intArray.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }

        [Test]
        public void ParallelWhereAggregateSumList()
        {
            var a =
                intList.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x);

            var b = intList.WhereAggregateP(onlyEvenInts, (acc, x) => acc += x);

            var c = intList.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void ParallelWhereAggregateSelectorList()
        {
            var a =
                intList.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            var b = intList.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }

    }
}

