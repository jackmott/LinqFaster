using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class SelectManyTests
    {

        [Test]
        public void SelectManyArray()
        {
            var a = Program.floatArray.SelectManyF(x => LinqFaster.RepeatArrayF(x, 2));
            var b = Program.floatArray.SelectMany(x => Enumerable.Repeat(x, 2).ToArray()).ToArray();

            Assert.That(a, Is.EqualTo(b));

            a = Program.floatArray.SelectManyF((x,i) => LinqFaster.RepeatArrayF(x+i, 2));
            b = Program.floatArray.SelectMany((x,i) => Enumerable.Repeat(x+i, 2).ToArray()).ToArray();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectManyList()
        {
            var a = Program.floatList.SelectManyF(x => LinqFaster.RepeatListF(x, 2));
            var b = Program.floatList.SelectMany(x => Enumerable.Repeat(x, 2).ToList()).ToList();

            Assert.That(a, Is.EqualTo(b));

            a = Program.floatList.SelectManyF((x, i) => LinqFaster.RepeatListF(x + i, 2));
            b = Program.floatList.SelectMany((x, i) => Enumerable.Repeat(x + i, 2).ToList()).ToList();

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
