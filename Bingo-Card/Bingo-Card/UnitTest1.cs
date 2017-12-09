using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bingo_Card
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }
    }

    public class BingoCard
    {
        public static string [] GetCard()
        {
            var card = new string[24];
            ;
            return card;
        }
    }
}
