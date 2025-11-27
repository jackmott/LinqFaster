using System;
using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class WhereTests
    {

        [Test]
        public void WhereEmpty()
        {
            int[] emptyArray = new int[0];

            Assert.DoesNotThrow(() =>
            {
                int[] a = emptyArray.WhereF(x => x == 0);
                List<int> emptyList = new System.Collections.Generic.List<int>(0);
                List<int> b = emptyList.WhereF(x => x == 0);
            });

        }


        [Test]
        public void WhereArray()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            int[] a = intArray.WhereF(lambda1);
            IEnumerable<int> b = intArray.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));

            string[] c = stringArray.WhereF(x => x == "no matches");
            IEnumerable<string> d = stringArray.Where(x => x == "no matches");

        }

        [Test]
        public void WhereList()
        {
            Func<int, int, bool> lambda1 = ((x, i) => x + i % 2 == 0);
            List<int> a = intList.WhereF(lambda1);
            IEnumerable<int> b = intList.Where(lambda1);
            Assert.That(a, Is.EqualTo(b));


            List<string> c = stringList.WhereF(x => x == "no matches");
            IEnumerable<string> d = stringList.Where(x => x == "no matches");

        }

    }
}
