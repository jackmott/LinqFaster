using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class ContainsSIMDTests
    {

        [Test]
        public void ContainsSIMDYes()
        {
            bool a = Test.intArray.Contains(0);
            bool b = Test.intArray.ContainsS(0);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ContainsSIMDNo()
        {
            bool a = Test.longArray.Contains(9999999);
            bool b = Test.longArray.ContainsS(9999999);

            Assert.That(a, Is.EqualTo(b));
        }
        
    }
}