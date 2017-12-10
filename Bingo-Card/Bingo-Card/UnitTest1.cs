using System.Linq;
using System.Text.RegularExpressions;
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

        [Test]
        public void NumbersAreOrderedByColumn()
        {
            var columns = string.Join("", BingoCard.GetCard().ToList()
                .Select(x => x.Substring(0, 1)).ToArray());

            Assert.IsTrue(Regex.IsMatch(columns, "^[B]*[I]*[N]*[G]*[O]*$"));
        }
    }
}
