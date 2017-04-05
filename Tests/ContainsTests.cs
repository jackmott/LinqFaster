using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using static Tests.Test;
using System.Collections.Generic;

namespace Tests
{
    [TestFixture]
    class ContainsTests {

        [Test]
        public void ContainsStringArrayTrue() {
            var a = stringArray.ContainsF("0",EqualityComparer<string>.Default);
            var b = stringArray.Contains("0", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));          
        }

        [Test]
        public void ContainsStringArrayFalse() {
            var a = stringArray.ContainsF("No Match", EqualityComparer<string>.Default);
            var b = stringArray.Contains("No Match", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ContainsStringListTrue() {
            var a = stringList.ContainsF("0", EqualityComparer<string>.Default);
            var b = stringList.Contains("0", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ContainsStringListFalse() {
            var a = stringList.ContainsF("no match", EqualityComparer<string>.Default);
            var b = stringList.Contains("no match", EqualityComparer<string>.Default);

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
