using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class WhereAggregateTests
    {
        [Test]
        public void WhereAggregateSumArray()
        {
            int a =
                intArray.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x);

            int b = intArray.WhereAggregateF(onlyEvenInts, (acc, x) => acc += x);

            int c = intArray.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void WhereAggregateSelectorArray()
        {
            int a =
                intArray.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            int b = intArray.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }

        [Test]
        public void WhereAggregateSumList()
        {
            int a =
                intList.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x);

            int b = intList.WhereAggregateF(onlyEvenInts, (acc, x) => acc += x);

            int c = intList.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void WhereAggregateSelectorList()
        {
            int a =
                intList.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            int b = intList.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }



    }
}
