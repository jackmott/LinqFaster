using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class MaxParallel
    {

        public void HelperMax<T>(T[] array)
        {
            T a = array.MaxP();
            T b = array.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMax<T>(List<T> list)
        {
            T a = list.MaxP();
            T b = list.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMax<T, U>(T[] array, Func<T, U> selector)
        {
            U a = array.MaxP(selector);
            U b = array.Max(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMax<T, U>(List<T> list, Func<T, U> selector)
        {
            U a = list.MaxP(selector);
            U b = list.Max(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelMaxArray()
        {
            HelperMax(intArray);
            HelperMax(floatArray);
            HelperMax(intArray, x => x.ToString());
            HelperMax(floatArray, x => x.ToString());
            HelperMax(stringArray);
            HelperMax(stringArray, x => (string)null);
            HelperMax(stringArray, x => int.Parse(x));
        }

        [Test]
        public void ParallelMaxList()
        {
            HelperMax(intList);
            HelperMax(floatList);
            HelperMax(intList, x => x.ToString());
            HelperMax(floatList, x => x.ToString());
            HelperMax(stringList);
            HelperMax(stringList, x => (string)null);
            HelperMax(stringList, x => int.Parse(x));
        }
    }
}

