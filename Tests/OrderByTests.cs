using NUnit.Framework;
using JM.LinqFaster;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Tests
{
    [TestFixture]
    class OrderByTests
    {
        [Test]
        public void OrderByArray()
        {
            Func<int,int> lambda1 = (x => x*x);
            var a = Program.intArray.OrderByF(lambda1);
            for (int i = 0; i < a.Length-1;i++)
            {
                Assert.That(lambda1(a[i]), Is.LessThanOrEqualTo(lambda1(a[i+1])));
            }
            
        }

        [Test]
        public void OrderByList()
        {
            
        }

    }
}
