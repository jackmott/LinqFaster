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
        public void WhereEmpty()
        {
            var emptyArray = new int[0];

            Assert.DoesNotThrow(() =>
            {
                var a = emptyArray.WhereF(x => x == 0);
                var emptyList = new System.Collections.Generic.List<int>(0);
                var b = emptyList.WhereF(x => x == 0);
            });
            
        }


        [Test]
        public void WhereArray()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = intArray.WhereF(lambda1);
            var b = intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            var c = stringArray.WhereF(x => x == "no matches");
            var d = stringArray.Where(x => x == "no matches");

        }

        [Test]
        public void WhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            var a = intList.WhereF(lambda1);
            var b = intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));


            var c = stringList.WhereF(x => x == "no matches");
            var d = stringList.Where(x => x == "no matches");

        }

    }
}
