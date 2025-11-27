using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class WhereParallel
    {
        [Test]
        public void ParallelWhereEmpty()
        {
            int[] emptyArray = new int[0];

            Assert.DoesNotThrow(() =>
            {
                int[] a = emptyArray.WhereP(x => x == 0);
                List<int> emptyList = new System.Collections.Generic.List<int>(0);
                List<int> b = emptyList.WhereP(x => x == 0);
            });

        }

        [Test]
        public void ParallelWhereArray()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            int[] a = intArray.WhereP(lambda1);
            IEnumerable<int> b = intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            string[] c = stringArray.WhereP(x => x == "no matches");
            IEnumerable<string> d = stringArray.Where(x => x == "no matches");

        }

        [Test]
        public void ParallelWhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            List<int> a = intList.WhereP(lambda1);
            IEnumerable<int> b = intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));


            List<string> c = stringList.WhereP(x => x == "no matches");
            IEnumerable<string> d = stringList.Where(x => x == "no matches");

        }

    }
}

