using System;
using System.Linq;

using JM.LinqFaster;
using JM.LinqFasterSpan;

using NUnit.Framework;

using static Tests.Test;

namespace Tests
{
    [TestFixture]
    internal class AggregateTests
    {
        [Test, Category("TEST")]
        public void AggregateArray()
        {

            int a = intArray.AggregateF(addXInts);
            int aSpan = intArray.AsSpan().AggregateF(addXInts);
            int b = intArray.Aggregate(addXInts);
            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));


            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            string seed = "seed";
            string c = intArray.AggregateF(seed, lambda2);
            string d = intArray.Aggregate(seed, lambda2);
            Assert.That(c, Is.EqualTo(d));

            string cSpan = intArray.AsSpan().AggregateF(seed, lambda2);
            Assert.That(cSpan, Is.EqualTo(d));

            string e = intArray.AggregateF(seed, lambda2, (x => ""));
            string f = intArray.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }

        [Test]
        public void AggregateList()
        {

            int a = intList.AggregateF(addXInts);
            int b = intList.Aggregate(addXInts);
            Assert.That(a, Is.EqualTo(b));

            Func<string, int, string> lambda2 = (acc, x) => acc += x;

            string seed = "seed";
            string c = intList.AggregateF(seed, lambda2);
            string d = intList.Aggregate(seed, lambda2);

            Assert.That(c, Is.EqualTo(d));

            string e = intList.AggregateF(seed, lambda2, (x => ""));
            string f = intList.Aggregate(seed, lambda2, (x => ""));

            Assert.That(e, Is.EqualTo(f));

        }
    }
}
