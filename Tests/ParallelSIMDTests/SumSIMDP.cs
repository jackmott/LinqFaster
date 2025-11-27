using NUnit.Framework;
using JM.LinqFaster.SIMD.Parallel;
using System.Linq;

namespace Tests
{
    [TestFixture]
    class SumSIMDP
    {
        [Test]
        public  void SumSIMDPArray()
        {
            int a = Test.intArray.SumSP();
            int b = Test.intArray.Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = Test.floatArray.SumSP();
            float d = Test.floatArray.Sum();

//            Assert.That(c, Is.EqualTo(d));

         
  //          Assert.That(e, Is.EqualTo(f));
        }
      
    }
}
