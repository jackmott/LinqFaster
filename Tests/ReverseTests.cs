using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System;
using static Tests.Test;

namespace Tests
{
    [TestFixture]
    class ReverseTests {

        [Test]
        public void ReverseArray() {
            var a = intArray.ReverseF();
            var aSpan = intArray.AsSpan().ReverseF();
            var b = intArray.Reverse();

            Assert.That(a, Is.EqualTo(b));
            Assert.That(aSpan, Is.EqualTo(b));
        }

        [Test]
        public void ReverseList() {
            var a = intList.ReverseF();
            var b = intList.Select(x => x).ToList();
            b.Reverse();
            Assert.That(a, Is.EqualTo(b));
        }
    }
}
