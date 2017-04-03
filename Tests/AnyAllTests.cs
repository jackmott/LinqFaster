using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class AnyAllTests
    {
       
        [Test]
        public void AllArray()
        {            
            var a = intArray.AllF(onlyEvenInts);
            var b = intArray.All(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));            
        }


        [Test]
        public void AllList()
        {            
            var a = intList.AllF(onlyEvenInts);
            var b = intList.All(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AnyArray()
        {
            
            Func<int, bool> nines = (x => x == 999999);

            var a = intArray.AnyF();
            var b = intArray.Any();

            Assert.That(a, Is.EqualTo(b));

            
            a = intArray.AnyF();
            b = intArray.Any();

            Assert.That(a, Is.EqualTo(b));

            a = intArray.AnyF(onlyEvenInts);
            b = intArray.Any(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.AnyF(nines);
            b = intArray.Any(nines);

            Assert.That(a, Is.EqualTo(b));

        }

        [Test]
        public void AnyList()
        {
            
            Func<int, bool> nines = (x => x == 999999);

            var a = intList.AnyF();
            var b = intList.Any();

            Assert.That(a, Is.EqualTo(b));


            a = intList.AnyF();
            b = intList.Any();

            Assert.That(a, Is.EqualTo(b));

            a = intList.AnyF(onlyEvenInts);
            b = intList.Any(onlyEvenInts);

            Assert.That(a, Is.EqualTo(b));

            a = intList.AnyF(nines);
            b = intList.Any(nines);

            Assert.That(a, Is.EqualTo(b));

        }
    }
}
