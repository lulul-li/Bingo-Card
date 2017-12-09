using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Bingo_Card
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void CardHas24Numbers()
        {
            Assert.AreEqual(24, BingoCard.GetCard().Length);
        }
        [Test]
        public void EachNumberOnCardIsUnique()
        {
            var card = BingoCard.GetCard();
            Assert.AreEqual(card.Length, card.ToList().Distinct().Count());
        }
        [TestCase("B", 5)]
        [TestCase("I", 5)]
        [TestCase("N", 4)]
        [TestCase("G", 5)]
        [TestCase("O", 5)]
        public void ColumnContainsCorrectNumberOfItems(string column, int count)
        {
            var numbers = BingoCard.GetCard().Where(x => x.StartsWith(column)).ToList();
            Assert.AreEqual(count, numbers.Count);
        }
    }

    public class BingoCard
    {
        private static Dictionary<int, string> columnName = new Dictionary<int, string>()
        {
            {0, "B"},
            {1, "I"},
            {2, "N"},
            {3, "G"},
            {4, "O"},
        };

        public static string[] GetCard()
        {
            var card = new string[24];
            for (var i = 0; i < card.Length; i++)
            {
                var index = i > 10 ? i + 1 : i;
                var row = index / 5;

                var min = index + row * 15;
                var max = min + 14;
                card[i] = columnName[row] + new Random().Next(min, max);
                while (card.Distinct().Count() < i + 1)
                {
                    card[i] = columnName[row] + new Random().Next(min, max);
                }
            }
            return card;
        }
    }
}
