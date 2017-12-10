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
        private static int _columns=5;

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
                var row = GetIndex(i) / _columns;
                var min = GetIndex(i) + row * _range;
                var max = min + _range - 1;

                Card[i] = _columnName[row] + new Random().Next(min, max);
                while (EachNumberOnCardIsNotUnique(i))
                {
                    Card[i] = _columnName[row] + new Random().Next(min, max);
                }
            }
        }

        private static int GetIndex(int i)
        {
            return i > 10 ? i + 1 : i;
        }

        private static bool EachNumberOnCardIsNotUnique(int i)
        {
            return Card.Distinct().Count() < i + 1;
        }
    }
}