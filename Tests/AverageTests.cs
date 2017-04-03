using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class AverageTests
    {
       
        [Test]
        public void AverageArrayInt()
        {
            var a = intArray.AverageF();
            var b = intArray.Average();

            Assert.That(a, Is.EqualTo(b));            
        }

        [Test]
        public void AverageArrayLong()
        {
            var a = Test.longArray.AverageF();
            var b = Test.longArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayFloat()
        {
            var a = floatArray.AverageF();
            var b = floatArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDouble()
        {
            var a = Test.doubleArray.AverageF();
            var b = Test.doubleArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDecimal()
        {
            var a = decimalArray.AverageF();
            var b = decimalArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            var a = stringArray.AverageF(lambda);
            var b = stringArray.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }


        // ------------------------- Lists


        [Test]
        public void AverageListInt() {
            var a = intList.AverageF();
            var b = intList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListLong() {
            var a = Test.longList.AverageF();
            var b = Test.longList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListFloat() {
            var a = floatList.AverageF();
            var b = floatList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListDouble() {
            var a = Test.doubleList.AverageF();
            var b = Test.doubleList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListDecimal() {
            var a = decimalList.AverageF();
            var b = decimalList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListString() {
            Func<string, float> lambda = (x => int.Parse(x));
            var a = stringList.AverageF(lambda);
            var b = stringList.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
