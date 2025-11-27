using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    internal class RepeatTests
    {
        [Test]
        public void RepeatArray()
        {
            float[] a = LinqFaster.RepeatArrayF(2.0f, 10);
            List<float> b = Enumerable.Repeat(2.0f, 10).ToList();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void RepeatList()
        {
            List<float> a = LinqFaster.RepeatListF(2.0f, 10);
            List<float> b = Enumerable.Repeat(2.0f, 10).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
