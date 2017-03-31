using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    class AnyAllTests
    {
       
        [Test]
        public void AllArray()
        {
            Func<int, bool> lambda = (x => x % 2 == 0);
            var a = Program.intArray.AllF(lambda);
            var b = Program.intArray.All(lambda);

            Assert.That(a, Is.EqualTo(b));
            
        }


        [Test]
        public void AllList()
        {
            Func<int, bool> lambda = (x => x % 2 == 0);
            var a = Program.intList.AllF(lambda);
            var b = Program.intList.All(lambda);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AnyArray()
        {
            Func<int, bool> lambda = (x => x % 2 == 0);
            Func<int, bool> lambda2 = (x => x == 999999);

            var a = Program.intArray.AnyF();
            var b = Program.intArray.Any();

            Assert.That(a, Is.EqualTo(b));

            
            a = Program.intArray.AnyF();
            b = Program.intArray.Any();

            Assert.That(a, Is.EqualTo(b));

            a = Program.intArray.AnyF(lambda);
            b = Program.intArray.Any(lambda);

            Assert.That(a, Is.EqualTo(b));

            a = Program.intArray.AnyF(lambda2);
            b = Program.intArray.Any(lambda2);

            Assert.That(a, Is.EqualTo(b));

        }

        [Test]
        public void AnyList()
        {
            Func<int, bool> lambda = (x => x % 2 == 0);
            Func<int, bool> lambda2 = (x => x == 999999);

            var a = Program.intList.AnyF();
            var b = Program.intList.Any();

            Assert.That(a, Is.EqualTo(b));


            a = Program.intList.AnyF();
            b = Program.intList.Any();

            Assert.That(a, Is.EqualTo(b));

            a = Program.intList.AnyF(lambda);
            b = Program.intList.Any(lambda);

            Assert.That(a, Is.EqualTo(b));

            a = Program.intList.AnyF(lambda2);
            b = Program.intList.Any(lambda2);

            Assert.That(a, Is.EqualTo(b));

        }
    }
}
