using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class LastTests {

        [Test]
        public void LastArray() {
            var a = intArray.LastF();
            var b = intArray.Last();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastArrayPredicate() {
            var a = intArray.LastF(x => x > 0);
            var b = intArray.Last(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastOrDefaultArray() {
            var a = intArray.LastOrDefaultF(x => x > 99999);
            var b = intArray.LastOrDefault(x => x >  99999);
            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void LastList() {
            var a = intList.LastF();
            var b = intList.Last();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastListPredicate() {
            var a = intList.LastF(x => x > 0);
            var b = intList.Last(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void LastOrDefaultList() {
            var a = intList.LastOrDefaultF(x => x > 99999);
            var b = intList.LastOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
