using NUnit.Framework;
using JM.LinqFaster;
using static Tests.Test;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class SingleTests {

        public int SingleArrayFunc() {
            return intArray.SingleF(onlyEvenInts);
        }

        public int SingleOrDefaultArrayFunc() {
            return intArray.SingleOrDefaultF(onlyEvenInts);
        }

        public int SingleListFunc() {
            return intList.SingleF(onlyEvenInts);
        }

        public int SingleOrDefaultListFunc() {
            return intList.SingleOrDefaultF(onlyEvenInts);
        }



        [Test]
        public void SingleArrayMoreThanOne() {                        
            Assert.Throws<InvalidOperationException>(() => intArray.SingleF());
            Assert.That(SingleArrayFunc, Throws.Exception);
        }

        [Test]
        public void SingleArrayOne() {
            int[] test = { 4 };

            var a = test.SingleF();
            var b = test.SingleF(onlyEvenInts);

            Assert.That(a, Is.EqualTo(4));
            Assert.That(b, Is.EqualTo(4));

        }

        [Test]
        public void SingleArrayDefaultOne() {
            int[] test = { 4 };

            var a = test.SingleOrDefaultF();
            var b = test.SingleOrDefaultF(onlyEvenInts);

            Assert.That(a, Is.EqualTo(4));
            Assert.That(b, Is.EqualTo(4));
        }

        [Test]
        public void SingleArrayDefaultEmpty() {
            int[] test = { };

            var a = test.SingleOrDefaultF();
            var b = test.SingleOrDefaultF(onlyEvenInts);

            Assert.That(a, Is.EqualTo(0));
            Assert.That(b, Is.EqualTo(0));
        }

        [Test]
        public void SingleArrayDefaultMoreThanOne() {
            Assert.Throws<InvalidOperationException>(() => intArray.SingleOrDefaultF());
            Assert.That(SingleOrDefaultArrayFunc, Throws.Exception);
        }

        // List

        [Test]
        public void SingleListMoreThanOne() {
            Assert.Throws<InvalidOperationException>(() => intList.SingleF());
            Assert.That(SingleListFunc, Throws.Exception);
        }

        [Test]
        public void SingleListOne() {
            List<int> test = new List<int>();
            test.Add(4);
            var a = test.SingleF();
            var b = test.SingleF(onlyEvenInts);

            Assert.That(a, Is.EqualTo(4));
            Assert.That(b, Is.EqualTo(4));
        }

        [Test]
        public void SingleListDefaultOne() {
            List<int> test = new List<int>();
            test.Add(4);

            var a = test.SingleOrDefaultF();
            var b = test.SingleOrDefaultF(onlyEvenInts);

            Assert.That(a, Is.EqualTo(4));
            Assert.That(b, Is.EqualTo(4));
        }

        [Test]
        public void SingleListDefaultEmpty() {
            List<int> test = new List<int>();            

            var a = test.SingleOrDefaultF();
            var b = test.SingleOrDefaultF(onlyEvenInts);
            Assert.That(a, Is.EqualTo(0));
            Assert.That(b, Is.EqualTo(0));
        }

        [Test]
        public void SingleListDefaultMoreThanOne() {
            Assert.Throws<InvalidOperationException>(() => intList.SingleOrDefaultF());
            Assert.That(SingleOrDefaultListFunc, Throws.Exception);
        }

    }
}
