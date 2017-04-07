using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class WhereSumTests
    {
        [Test]
        public  void WhereSumArray()
        {
            var a = intArray.WhereSumF(x => x % 2 == 0);
            var b = intArray.Where(x=>x%2==0).Sum();

            Assert.That(a, Is.EqualTo(b));

           
        }

        [Test]
        public void WhereSumArraySelector() {
            var a = intArray.WhereSumF(x => x % 2 == 0,x=>x+1);
            var b = intArray.Where(x => x % 2 == 0).Sum(x=>x+1);

            Assert.That(a, Is.EqualTo(b));

        }

        [Test]
        public void WhereSumList()
        {
            var a = intList.WhereSumF(x => x % 2 == 0);
            var b = intList.Where(x => x % 2 == 0).Sum();

            
        }

        [Test]
        public void WhereSumListSelector() {
            var a = intList.WhereSumF(x => x % 2 == 0, x => x + 1);
            var b = intList.Where(x => x % 2 == 0).Sum(x => x + 1);

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
