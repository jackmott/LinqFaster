using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;

namespace Tests
{
    [TestFixture]
    class AverageParallel
    {        
        [Test]
        public void ParallelAverageArrayInt()
        {
            var a = intArray.AverageP();
            var b = intArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageArrayLong()
        {
            var a = longArray.AverageP();
            var b = longArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageArrayFloat()
        {
            var a = floatArray.AverageP();
            var b = floatArray.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
        }

        [Test]
        public void ParallelAverageArrayDouble()
        {
            var a = Test.doubleArray.AverageP();
            var b = Test.doubleArray.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageArrayDecimal()
        {
            var a = decimalArray.AverageP();
            var b = decimalArray.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
            
        }

        [Test]
        public void ParallelAverageArrayString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            var a = stringArray.AverageP(lambda);
            var b = stringArray.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }


        // ------------------------- Lists


        [Test]
        public void ParallelAverageListInt()
        {
            var a = intList.AverageP();
            var b = intList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageListLong()
        {
            var a = Test.longList.AverageP();
            var b = Test.longList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageListFloat()
        {
            var a = floatList.AverageP();
            var b = floatList.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
        }

        [Test]
        public void ParallelAverageListDouble()
        {
            var a = Test.doubleList.AverageP();
            var b = Test.doubleList.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageListDecimal()
        {
            var a = decimalList.AverageP();
            var b = decimalList.Average();
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageListString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            var a = stringList.AverageP(lambda);
            var b = stringList.Average(lambda);
            var diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
            
        }

    }
}
