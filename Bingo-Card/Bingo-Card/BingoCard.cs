using System;
using System.Collections.Generic;
using System.Linq;

namespace Bingo_Card
{
    public class BingoCard
    {
        private static Dictionary<int, string> _columnName = new Dictionary<int, string>()
        {
            {0, "B"},
            {1, "I"},
            {2, "N"},
            {3, "G"},
            {4, "O"},
        };

        private static int _range = 15;
        private static int _columns = 5;
        private static int _3rdColumn = 10;

        public static string[] Card { get; set; }

        public static string[] GetCard()
        {
            NewCard();
            SetRandomValue();
            return Card;
        }

        private static void NewCard()
        {
            Card = new string[24];
        }

        private static void SetRandomValue()
        {
            for (var i = 0; i < Card.Length; i++)
            {
                while (EachNumberOnCardIsNotUnique(i))
                {
                    Card[i] = _columnName[GetColumnIndex(i)] + new Random().Next(Min(i), Min(i)+_range);
                }
            }
        }
        

        private static int Min(int i)
        {
            return GetColumnIndex(i) * _range + 1;
        }

        private static int GetColumnIndex(int i)
        {
            return (i > _3rdColumn ? i + 1 : i) / _columns;
        }

        private static bool EachNumberOnCardIsNotUnique(int i)
        {
            return Card.Where(x => !string.IsNullOrEmpty(x)).Distinct().Count() <= i;
        }
    }
}