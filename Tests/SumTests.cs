using System;
using System.Collections.Generic;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class SumTests
    {
        [Test]
        public void NonOverflowOfComputableSumSingle()
        {
            float[] source = { float.MaxValue, float.MaxValue,
                -float.MaxValue, -float.MaxValue };
            // In a world where we summed using a float accumulator, the
            // result would be infinity.
            Assert.AreEqual(0f, source.Sum());
        }

        [Test]
        public void AccumulatorAccuracyForSingle()
        {
            // 20000000 and 20000004 are both exactly representable as
            // float values, but 20000001 is not. Therefore if we use
            // a float accumulator, we’ll end up with 20000000. However,
            // if we use a double accumulator, we’ll get the right value.
            float[] array = { 20000000f, 1f, 1f, 1f, 1f };
            Assert.AreEqual(20000004f, array.SumF());
        }

        [Test]
        public void OverflowOfComputableSumInt32()
        {
            int[] source = { int.MaxValue, 1, -1, -int.MaxValue };
            // In a world where we summed using a long accumulator, the
            // result would be 0.
            Assert.Throws<OverflowException>(() => source.Sum());
            Assert.DoesNotThrow(() => source.SumF());
        }

        [Test]
        public void SumArray()
        {
            int a = ((IReadOnlyList<int>)intArray).SumF();

            int b = intArray.Sum();
            Assert.That(a, Is.EqualTo(b));
            int? an = ((IReadOnlyList<int?>)intNullArray).SumF();
            int? bn = intNullArray.Sum();
            Assert.That(an, Is.EqualTo(bn));

            float c = floatArray.SumF();
            float d = floatArray.Sum();
            Assert.That(c, Is.EqualTo(d));
            float? dn = floatNullArray.SumF();
            Assert.That(c, Is.EqualTo(dn));

            decimal e = decimalArray.SumF();
            decimal f = decimalArray.Sum();
            Assert.That(e, Is.EqualTo(f));

            uint g = byteArray.SumF();
            uint h = byteArray.Aggregate(0U, (current, b1) => current + b1);
            Assert.That(g, Is.EqualTo(h));

            int i = shortArray.SumF();
            int j = shortArray.Aggregate(0, (current, s1) => current + s1);
            Assert.That(i, Is.EqualTo(j));

            double k = doubleArray.SumF();
            double l = doubleArray.Sum();
            Assert.That(k, Is.EqualTo(l));
            double? ln = doubleNullArray.SumF();
            Assert.That(k, Is.EqualTo(ln));


        }


        [Test]
        public void SumArraySelector()
        {
            int a = intArray.SumF(x => x + 1);
            int b = intArray.Sum(x => x + 1);
            Assert.That(a, Is.EqualTo(b));

            int br = Array.AsReadOnly(intArray).SumF(x => x + 1);
            Assert.That(a, Is.EqualTo(br));

            int an = intNullArray.SumF(x => x ?? 0);
            int bn = intNullArray.Sum(x => x ?? 0);
            Assert.That(an, Is.EqualTo(bn));

            float c = floatArray.SumF(squaredFloats);
            float d = floatArray.Sum(squaredFloats);

            Assert.That(c, Is.EqualTo(d));
        }

        [Test]
        public void SumList()
        {
            int a = intList.SumF();
            int b = intList.Sum();

            Assert.That(a, Is.EqualTo(b));

            float c = floatList.SumF();
            float d = floatList.Sum();

            Assert.That(c, Is.EqualTo(d));

            decimal e = decimalList.SumF();
            decimal f = decimalList.Sum();

            Assert.That(e, Is.EqualTo(f));
        }

        [Test]
        public void SumListSelector()
        {
            int a = intList.SumF(x => x + 1);
            int b = intList.Sum(x => x + 1);
            Assert.That(a, Is.EqualTo(b));

            int br = intList.AsReadOnly().SumF(x => x + 1);
            Assert.That(a, Is.EqualTo(br));

            float c = floatList.SumF(squaredFloats);
            float d = floatList.Sum(squaredFloats);
            Assert.That(c, Is.EqualTo(d));
        }

    }
}
