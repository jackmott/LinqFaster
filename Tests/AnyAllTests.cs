using System.Linq;

using JM.LinqFaster;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class AnyAllTests
    {

        [Test]
        public void AllArray()
        {
            bool a = intArray.AllF(x => x % 2 == 0);
            bool b = intArray.All(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));
        }


        [Test]
        public void AllList()
        {
            bool a = intList.AllF(x => x % 2 == 0);
            bool b = intList.All(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AnyArray()
        {

            bool a = intArray.AnyF();
            bool b = intArray.Any();

            Assert.That(a, Is.EqualTo(b));


            a = intArray.AnyF();
            b = intArray.Any();

            Assert.That(a, Is.EqualTo(b));

            a = intArray.AnyF(x => x % 2 == 0);
            b = intArray.Any(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.AnyF(x => x == 999999);
            b = intArray.Any(x => x == 999999);

            Assert.That(a, Is.EqualTo(b));

        }

        [Test]
        public void AnyList()
        {

            bool a = intList.AnyF();
            bool b = intList.Any();

            Assert.That(a, Is.EqualTo(b));


            a = intList.AnyF();
            b = intList.Any();

            Assert.That(a, Is.EqualTo(b));

            a = intList.AnyF(x => x % 2 == 0);
            b = intList.Any(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));

            a = intList.AnyF(x => x == 999999);
            b = intList.Any(x => x == 999999);

            Assert.That(a, Is.EqualTo(b));

        }
    }
}
