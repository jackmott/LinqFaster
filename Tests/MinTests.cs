using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class MinTests
    {
        public void HelperMin<T>(T[] array)
        {
            T a = array.MinF();
            T b = array.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T>(List<T> list)
        {
            T a = list.MinF();
            T b = list.Min();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T, U>(T[] array, Func<T, U> selector)
        {
            U a = array.MinF(selector);
            U b = array.Min(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMin<T, U>(List<T> list, Func<T, U> selector)
        {
            U a = list.MinF(selector);
            U b = list.Min(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MinArray()
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
        public void MinList()
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
