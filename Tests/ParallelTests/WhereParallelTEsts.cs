using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;

namespace Tests
{
    [TestFixture]
    class WhereParallel
    {

        [Test]
        public void ParallelWhereArray()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = intArray.WhereP(lambda1);
            var b = intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            var c = stringArray.WhereP(x => x == "no matches");
            var d = stringArray.Where(x => x == "no matches");

        }

        [Test]
        public void ParallelWhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = intList.WhereP(lambda1);
            var b = intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));


            var c = stringList.WhereP(x => x == "no matches");
            var d = stringList.Where(x => x == "no matches");

        }

    }
}

