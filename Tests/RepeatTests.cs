using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JM.LinqFaster;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class RepeatTests
    {
        [Test]
        public void RepeatList()
        {
            var a = LinqFaster.RepeatListF(2.0f, 10);
            var b = Enumerable.Repeat(2.0f, 10).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
