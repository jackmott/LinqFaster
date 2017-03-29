using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class SelectTests
    {
        [Test]
        public void SelectArray()
        {
            var a = Program.intArray.SelectF(x => x * x);
            var b = Program.intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));

            a = Program.intArray.SelectF((x, i) => x + i);
            b = Program.intArray.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SelectList()
        {
            var a = Program.intList.SelectF(x => x * x);
            var b = Program.intList.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));

            a = Program.intList.SelectF((x, i) => x + i);
            b = Program.intList.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
