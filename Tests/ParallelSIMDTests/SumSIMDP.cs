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
            var a = Program.intArray.SumSP();
            var b = Program.intArray.Sum();

           // Assert.That(a, Is.EqualTo(b));

            var c = Program.floatArray.SumSP();
            var d = Program.floatArray.Sum();

//            Assert.That(c, Is.EqualTo(d));

         
  //          Assert.That(e, Is.EqualTo(f));
        }
      
    }
}
