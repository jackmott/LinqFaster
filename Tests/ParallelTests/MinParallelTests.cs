using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class MinParallel
    {

        public void HelperMin<T>(T[] array)
        {
            T a = array.MinP();
            T b = array.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T>(List<T> list)
        {
            T a = list.MinP();
            T b = list.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T, U>(T[] array, Func<T, U> selector)
        {
            U a = array.MinP(selector);
            U b = array.Min(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T, U>(List<T> list, Func<T, U> selector)
        {
            U a = list.MinP(selector);
            U b = list.Min(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelMinArray()
        {
            HelperMin(intArray);
            HelperMin(floatArray);
            HelperMin(intArray, x => x.ToString());
            HelperMin(floatArray, x => x.ToString());
            HelperMin(stringArray);
            HelperMin(stringArray, x => (string)null);
            HelperMin(stringArray, x => int.Parse(x));
        }

        [Test]
        public void ParallelMinList()
        {
            HelperMin(intList);
            HelperMin(floatList);
            HelperMin(intList, x => x.ToString());
            HelperMin(floatList, x => x.ToString());
            HelperMin(stringList, x => (string)null);
            HelperMin(stringList, x => int.Parse(x));
        }
    }
}

