using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereSelectTests
    {
        [Test]
        public void WhereSelectArray()
        {            
            var a = intArray.WhereSelectF(onlyEvenInts,squaredInts);
            var b = intArray.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool>  lambda2 = (x => x == "no matches");

            var c = stringArray.WhereSelectF(lambda2, x => x + "append");
            var d = stringArray.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSelectIndexArray() {
            var a = intArray.WhereSelectF((x,i) => x+i % 2 == 0, (x,i) => x+i);
            var b = intArray.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));           
        }

        [Test]
        public void WhereSelectList() {
            var a = intList.WhereSelectF(onlyEvenInts, squaredInts);
            var b = intList.Where(onlyEvenInts).Select(squaredInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, bool> lambda2 = (x => x == "no matches");

            var c = stringList.WhereSelectF(lambda2, x => x + "append");
            var d = stringList.Where(lambda2).Select(x => x + "append");

            Assert.That(c, Is.EqualTo(d));

        }

        [Test]
        public void WhereSelectIndexList() {
            var a = intList.WhereSelectF((x, i) => x + i % 2 == 0, (x, i) => x + i);
            var b = intList.Where((x, i) => x + i % 2 == 0).Select((x, i) => x + i);
            Assert.That(a, Is.EqualTo(b));
        }


    }
}
