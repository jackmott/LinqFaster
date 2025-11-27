using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class WhereSelectParallel
    {
        [Test]
        public void ParallelWhereSelectArray()
        {
            int[] a = intArray.WhereSelectP(onlyEvenInts, squaredInts);
            IEnumerable<int> b = intArray.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            string[] c = stringArray.WhereSelectP(lambda2, x => x + "append");
            IEnumerable<string> d = stringArray.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void ParallelWhereSelectIndexArray()
        {
            int[] a = intArray.WhereSelectP((x, i) => x + i % 2 == 0, (x, i) => x + i);
            IEnumerable<int> b = intArray.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelWhereSelectList()
        {
            List<int> a = intList.WhereSelectP(onlyEvenInts, squaredInts);
            IEnumerable<int> b = intList.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            List<string> c = stringList.WhereSelectP(lambda2, x => x + "append");
            IEnumerable<string> d = stringList.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void ParallelWhereSelectIndexList()
        {
            List<int> a = intList.WhereSelectP((x, i) => x + i % 2 == 0, (x, i) => x + i);
            IEnumerable<int> b = intList.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }


    }
}

