using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class FirstTests {

        [Test]
        public void FirstArray() {
            var a = intArray.FirstF();
            var b = intArray.First();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstArrayPredicate() {
            var a = intArray.FirstF(x => x > 0);
            var b = intArray.First(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstOrDefaultArray() {
            var a = intArray.FirstOrDefaultF(x => x > 99999);
            var b = intArray.FirstOrDefault(x => x >  99999);
            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void FirstList() {
            var a = intList.FirstF();
            var b = intList.First();
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstListPredicate() {
            var a = intList.FirstF(x => x > 0);
            var b = intList.First(x => x > 0);
            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void FirstOrDefaultList() {
            var a = intList.FirstOrDefaultF(x => x > 99999);
            var b = intList.FirstOrDefault(x => x > 99999);
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
