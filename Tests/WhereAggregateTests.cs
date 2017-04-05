using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereAggregateTests
    {
        [Test]
        public void WhereAggregateSumArray()
        {
            var a =
                intArray.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x);

            var b = intArray.WhereAggregateF(onlyEvenInts, (acc, x) => acc += x);

            var c = intArray.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));            

        }

        [Test]
        public void WhereAggregateSelectorArray() {
            var a =
                intArray.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x, acc =>acc/2);
            

            var b = intArray.Where(onlyEvenInts).Sum()/2;

            Assert.That(a, Is.EqualTo(b));
            

        }

        [Test]
        public void WhereAggregateSumList() {
            var a =
                intList.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x);

            var b = intList.WhereAggregateF(onlyEvenInts, (acc, x) => acc += x);

            var c = intList.Where(onlyEvenInts).Sum();

            Assert.That(a, Is.EqualTo(c));
            Assert.That(b, Is.EqualTo(c));

        }

        [Test]
        public void WhereAggregateSelectorList() {
            var a =
                intList.WhereAggregateF(onlyEvenInts, 0, (acc, x) => acc += x, acc => acc / 2);


            var b = intList.Where(onlyEvenInts).Sum() / 2;

            Assert.That(a, Is.EqualTo(b));


        }



    }
}
