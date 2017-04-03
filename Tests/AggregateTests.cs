using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class AggregateTests
    {
        [Test, Category("TEST")]
        public void AggregateArray()
        {
            
            var a = intArray.AggregateF(addXInts);
            var b = intArray.Aggregate(addXInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            var seed = "seed";
            var c = intArray.AggregateF(seed,lambda2);
            var d = intArray.Aggregate(seed,lambda2);

            Assert.That(a, Is.EqualTo(b));

            var e = intArray.AggregateF(seed, lambda2, (x => ""));
            var f = intArray.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }

        [Test]
        public void AggregateList()
        {
            
            var a = intList.AggregateF(addXInts);
            var b = intList.Aggregate(addXInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            var seed = "seed";
            var c = intList.AggregateF(seed, lambda2);
            var d = intList.Aggregate(seed, lambda2);

            Assert.That(c, Is.EqualTo(d));

            var e = intList.AggregateF(seed, lambda2, (x => ""));
            var f = intList.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }
    }
}
