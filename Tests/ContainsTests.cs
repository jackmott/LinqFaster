using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests {
    [TestFixture]
    class ContainsTests {

        [Test]
        public void ContainsStringArrayTrue() {
            var a = stringArray.ContainsF("0");
            var b = stringArray.Contains("0");

            Assert.That(a, Is.EqualTo(b));          
        }

        [Test]
        public void ContainsStringArrayFalse() {
            var a = stringArray.ContainsF("No Match");
            var b = stringArray.Contains("No Match");

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ContainsStringListTrue() {
            var a = stringList.ContainsF("0");
            var b = stringList.Contains("0");

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ContainsStringListFalse() {
            var a = stringList.ContainsF("no match");
            var b = stringList.Contains("no match");

            Assert.That(a, Is.EqualTo(b));
        }

    }
}
