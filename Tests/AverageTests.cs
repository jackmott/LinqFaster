using System;
using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class AverageTests
    {

        [Test]
        public void AverageArrayInt()
        {
            double a = intArray.AverageF();
            double b = intArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayLong()
        {
            double a = Test.longArray.AverageF();
            double b = Test.longArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayFloat()
        {
            float a = floatArray.AverageF();
            float b = floatArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDouble()
        {
            double a = Test.doubleArray.AverageF();
            double b = Test.doubleArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDecimal()
        {
            decimal a = decimalArray.AverageF();
            decimal b = decimalArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            float a = stringArray.AverageF(lambda);
            float b = stringArray.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }


        // ------------------------- Lists


        [Test]
        public void AverageListInt()
        {
            double a = intList.AverageF();
            double b = intList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListLong()
        {
            double a = Test.longList.AverageF();
            double b = Test.longList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListFloat()
        {
            float a = floatList.AverageF();
            float b = floatList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListDouble()
        {
            double a = Test.doubleList.AverageF();
            double b = Test.doubleList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListDecimal()
        {
            decimal a = decimalList.AverageF();
            decimal b = decimalList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageListString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            float a = stringList.AverageF(lambda);
            float b = stringList.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
