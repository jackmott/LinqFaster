using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class WhereTests
    {
        [Test]
        public void WhereArray()
        {
            Func<int,int, bool> lambda1 = ((x,i) => x+i % 2 == 0);
            var a = Program.intArray.WhereF(lambda1);
            var b = Program.intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool>  lambda2 = (x => x == "no matches");

            var c = Program.stringArray.WhereF(lambda2);
            var d = Program.stringArray.Where(lambda2);

        }

        [Test]
        public void WhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = Program.intList.WhereF(lambda1);
            var b = Program.intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            var c = Program.stringList.WhereF(lambda2);
            var d = Program.stringList.Where(lambda2);

        }

    }
}
