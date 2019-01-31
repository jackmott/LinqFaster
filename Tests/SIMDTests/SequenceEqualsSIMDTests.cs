using NUnit.Framework;
using JM.LinqFaster.SIMD;
using System.Linq;
using static Tests.Test;

namespace Tests {
    [TestFixture]
    class SequenceEqualsSIMDTests {

        [Test]
        public void SequenceEqualArray()
        {
            var intArray2 = (int[])intArray.Clone();
            var a = LinqFasterSIMD.SequenceEqualS(intArray, intArray2);
            var b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray()
        {
            var intArray2 = (int[])intArray.Clone();
            intArray2[3] = -10;
            var a = LinqFasterSIMD.SequenceEqualS(intArray, intArray2);
            var b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }    

    }
}
