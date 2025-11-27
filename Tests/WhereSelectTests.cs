using System;
using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class WhereSelectTests
    {
        [Test]
        public void WhereSelectArray()
        {
            int[] a = intArray.WhereSelectF(onlyEvenInts, squaredInts);
            IEnumerable<int> b = intArray.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            string[] c = stringArray.WhereSelectF(lambda2, x => x + "append");
            IEnumerable<string> d = stringArray.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSelectIndexArray()
        {
            int[] a = intArray.WhereSelectF((x, i) => x + i % 2 == 0, (x, i) => x + i);
            IEnumerable<int> b = intArray.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void WhereSelectList()
        {
            List<int> a = intList.WhereSelectF(onlyEvenInts, squaredInts);
            IEnumerable<int> b = intList.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            List<string> c = stringList.WhereSelectF(lambda2, x => x + "append");
            IEnumerable<string> d = stringList.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSelectIndexList()
        {
            List<int> a = intList.WhereSelectF((x, i) => x + i % 2 == 0, (x, i) => x + i);
            IEnumerable<int> b = intList.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }


    }
}
