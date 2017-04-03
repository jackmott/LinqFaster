using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;
using static Tests.Test;

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
            HelperMax(intArray);
            HelperMax(floatArray);
            HelperMax(intArray, x => x.ToString());
            HelperMax(floatArray, x => x.ToString());
            HelperMax(stringArray);
            HelperMax(stringArray, x => (string)null);
            HelperMax(stringArray, x => int.Parse(x));
        }

        [Test]
        public void MaxList()
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
