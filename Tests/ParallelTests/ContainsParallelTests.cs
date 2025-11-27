using NUnit.Framework;
using JM.LinqFaster.Parallel;
using System.Linq;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class ContainsParallel
    {
        [Test]
        public void ParallelContainsStringArrayTrue()
        {
            bool a = stringArray.ContainsP("0", EqualityComparer<string>.Default);
            bool b = stringArray.Contains("0", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelContainsStringArrayFalse()
        {
            bool a = stringArray.ContainsP("No Match", EqualityComparer<string>.Default);
            bool b = stringArray.Contains("No Match", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelContainsStringListTrue()
        {
            bool a = stringList.ContainsP("0", EqualityComparer<string>.Default);
            bool b = stringList.Contains("0", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelContainsStringListFalse()
        {
            bool a = stringList.ContainsP("no match", EqualityComparer<string>.Default);
            bool b = stringList.Contains("no match", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
