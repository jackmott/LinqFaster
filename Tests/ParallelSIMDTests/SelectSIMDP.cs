using NUnit.Framework;
using JM.LinqFaster.SIMD.Parallel;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class SelectSIMDPTests
    {
        [Test]
        public  void SelectSIMDP()
        {
            var a = Test.intArray.SelectSP(x => x * x, x => x*x);
            var b = Test.intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));

        
//            Assert.That(c, Is.EqualTo(d));

         
  //          Assert.That(e, Is.EqualTo(f));
        }
      
    }
}
