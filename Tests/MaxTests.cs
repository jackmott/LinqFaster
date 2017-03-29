using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class MaxTests
    {        
        public void HelperMax<T>(T[] array)
        {
            T a = array.MaxF();
            T b = array.Max();

            Assert.That(a, Is.EqualTo(b));            
        }

        public void HelperMax<T>(List<T> list)
        {
            T a = list.MaxF();
            T b = list.Max();

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMax<T,U>(T[] array, Func<T, U> selector)
        {
            U a = array.MaxF(selector);
            U b = array.Max(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        public void HelperMax<T,U>(List<T> list, Func<T,U> selector)
        {
            U a = list.MaxF(selector);
            U b = list.Max(selector);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void MaxArray()
        {
            HelperMax(Program.intArray);
            HelperMax(Program.floatArray);
            HelperMax(Program.intArray, x => x.ToString());
            HelperMax(Program.floatArray, x => x.ToString());
            HelperMax(Program.stringArray);
            HelperMax(Program.stringArray, x => (string)null);
            HelperMax(Program.stringArray, x => float.Parse(x));
        }

        [Test]
        public void MaxList()
        {
            HelperMax(Program.intList);
            HelperMax(Program.floatList);
            HelperMax(Program.intList, x => x.ToString());
            HelperMax(Program.floatList, x => x.ToString());
            HelperMax(Program.stringList);
            HelperMax(Program.stringList, x => (string)null);
            HelperMax(Program.stringList, x => float.Parse(x));
        }
    }
}
