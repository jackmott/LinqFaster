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
            int[] intArray2 = (int[])intArray.Clone();
            bool a = LinqFasterSIMD.SequenceEqualS(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void SequenceNotEqualArray()
        {
            int[] intArray2 = (int[])intArray.Clone();
            intArray2[3] = -10;
            bool a = LinqFasterSIMD.SequenceEqualS(intArray, intArray2);
            bool b = Enumerable.SequenceEqual(intArray, intArray2);

            Assert.That(a, Is.EqualTo(b));
        }    

    }
}
