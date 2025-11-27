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
            int a =
                intArray.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x);

            int b = intArray.WhereAggregateP(onlyEvenInts, (acc, x) => acc += x);

            int c = intArray.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void ParallelWhereAggregateSelectorArray()
        {
            int a =
                intArray.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            int b = intArray.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }

        [Test]
        public void ParallelWhereAggregateSumList()
        {
            int a =
                intList.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x);

            int b = intList.WhereAggregateP(onlyEvenInts, (acc, x) => acc += x);

            int c = intList.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void ParallelWhereAggregateSelectorList()
        {
            int a =
                intList.WhereAggregateP(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            int b = intList.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }

    }
}

