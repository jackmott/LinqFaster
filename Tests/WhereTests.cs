using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereTests
    {
        [Test]
        public void WhereArray()
        {
            Func<int,int, bool> lambda1 = ((x,i) => x+i % 2 == 0);
            var a = intArray.WhereF(lambda1);
            var b = intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool>  lambda2 = (x => x == "no matches");

            var c = stringArray.WhereF(lambda2);
            var d = stringArray.Where(lambda2);

        }

        [Test]
        public void WhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = intList.WhereF(lambda1);
            var b = intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            var c = stringList.WhereF(lambda2);
            var d = stringList.Where(lambda2);

        }

    }
}
