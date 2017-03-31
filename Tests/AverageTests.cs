using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    class AverageTests
    {
       
        [Test]
        public void AverageArrayInt()
        {
            var a = Program.intArray.AverageF();
            var b = Program.intArray.Average();

            Assert.That(a, Is.EqualTo(b));            
        }

        [Test]
        public void AverageArrayLong()
        {
            var a = Program.longArray.AverageF();
            var b = Program.longArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayFloat()
        {
            var a = Program.floatArray.AverageF();
            var b = Program.floatArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDouble()
        {
            var a = Program.doubleArray.AverageF();
            var b = Program.doubleArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayDecimal()
        {
            var a = Program.decimalArray.AverageF();
            var b = Program.decimalArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AverageArrayString()
        {
            Func<string, float> lambda = (x => float.Parse(x));
            var a = Program.stringArray.AverageF(lambda);
            var b = Program.stringArray.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
