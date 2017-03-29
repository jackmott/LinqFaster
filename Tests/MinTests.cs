using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

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
            HelperMin(Program.intArray);
            HelperMin(Program.floatArray);
            HelperMin(Program.intArray, x => x.ToString());
            HelperMin(Program.floatArray, x => x.ToString());
            HelperMin(Program.stringArray);
            HelperMin(Program.stringArray, x => (string)null);
            HelperMin(Program.stringArray, x => float.Parse(x));
        }

        [Test]
        public void MinList()
        {
            HelperMin(Program.intList);
            HelperMin(Program.floatList);
            HelperMin(Program.intList, x => x.ToString());
            HelperMin(Program.floatList, x => x.ToString());
            HelperMin(Program.stringList, x => (string)null);
            HelperMin(Program.stringList, x => float.Parse(x));
        }
    }
}
