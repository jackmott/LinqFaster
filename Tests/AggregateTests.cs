using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    class AggregateTests
    {
        [Test]
        public void AggregateArray()
        {
            Func<int, int, int> lambda = (x, acc) => acc += x;
            var a = Program.intArray.AggregateF(lambda);
            var b = Program.intArray.Aggregate(lambda);
            Assert.That(a, Is.EqualTo(b));

            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            var seed = "seed";
            var c = Program.intArray.AggregateF(seed,lambda2);
            var d = Program.intArray.Aggregate(seed,lambda2);

            Assert.That(a, Is.EqualTo(b));

            var e = Program.intArray.AggregateF(seed, lambda2, (x => ""));
            var f = Program.intArray.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }

        [Test]
        public void AggregateList()
        {
            Func<int, int, int> lambda = (x, acc) => acc += x;
            var a = Program.intList.AggregateF(lambda);
            var b = Program.intList.Aggregate(lambda);
            Assert.That(a, Is.EqualTo(b));

            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            var seed = "seed";
            var c = Program.intList.AggregateF(seed, lambda2);
            var d = Program.intList.Aggregate(seed, lambda2);

            Assert.That(c, Is.EqualTo(d));

            var e = Program.intList.AggregateF(seed, lambda2, (x => ""));
            var f = Program.intList.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }
    }
}
