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
            double a = intArray.AverageP();
            double b = intArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageArrayLong()
        {
            double a = longArray.AverageP();
            double b = longArray.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageArrayFloat()
        {
            float a = floatArray.AverageP();
            float b = floatArray.Average();
            float diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
        }

        [Test]
        public void ParallelAverageArrayDouble()
        {
            double a = Test.doubleArray.AverageP();
            double b = Test.doubleArray.Average();
            double diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageArrayDecimal()
        {
            decimal a = decimalArray.AverageP();
            decimal b = decimalArray.Average();
            decimal diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
            
        }

        [Test]
        public void ParallelAverageArrayString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            float a = stringArray.AverageP(lambda);
            float b = stringArray.Average(lambda);

            Assert.That(a, Is.EqualTo(b));
        }


        // ------------------------- Lists


        [Test]
        public void ParallelAverageListInt()
        {
            double a = intList.AverageP();
            double b = intList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageListLong()
        {
            double a = Test.longList.AverageP();
            double b = Test.longList.Average();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelAverageListFloat()
        {
            double a = floatList.AverageP();
            float b = floatList.Average();
            double diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
        }

        [Test]
        public void ParallelAverageListDouble()
        {
            double a = Test.doubleList.AverageP();
            double b = Test.doubleList.Average();
            double diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageListDecimal()
        {
            decimal a = decimalList.AverageP();
            decimal b = decimalList.Average();
            decimal diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1));
        }

        [Test]
        public void ParallelAverageListString()
        {
            Func<string, float> lambda = (x => int.Parse(x));
            double a = stringList.AverageP(lambda);
            float b = stringList.Average(lambda);
            double diff = Math.Abs(a-b);
            Assert.That(diff, Is.LessThan(0.1f));
            
        }

    }
}
