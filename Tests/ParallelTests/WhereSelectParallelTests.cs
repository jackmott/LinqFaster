using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;

namespace Tests
{
    [TestFixture]
    class WhereSelectParallel
    {
        [Test]
        public void ParallelWhereSelectArray()
        {
            var a = intArray.WhereSelectP(onlyEvenInts, squaredInts);
            var b = intArray.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            var c = stringArray.WhereSelectP(lambda2, x => x + "append");
            var d = stringArray.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void ParallelWhereSelectIndexArray()
        {
            var a = intArray.WhereSelectP((x, i) => x + i % 2 == 0, (x, i) => x + i);
            var b = intArray.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelWhereSelectList()
        {
            var a = intList.WhereSelectP(onlyEvenInts, squaredInts);
            var b = intList.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            var c = stringList.WhereSelectP(lambda2, x => x + "append");
            var d = stringList.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void ParallelWhereSelectIndexList()
        {
            var a = intList.WhereSelectP((x, i) => x + i % 2 == 0, (x, i) => x + i);
            var b = intList.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }


    }
}

