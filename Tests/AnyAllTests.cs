using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class AnyAllTests
    {
       
        [Test]
        public void AllArray()
        {            
            var a = intArray.AllF(x => x % 2 == 0);
            var b = intArray.All(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));            
        }


        [Test]
        public void AllList()
        {            
            var a = intList.AllF(x => x % 2 == 0);
            var b = intList.All(x => x % 2 == 0);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AnyArray()
        {
                        
            var a = intArray.AnyF();
            var b = intArray.Any();

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

            var a = intList.AnyF();
            var b = intList.Any();

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
