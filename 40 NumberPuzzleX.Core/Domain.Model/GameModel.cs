using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _40_NumberPuzzleX.Core.Domain.Model
{
    public class GameModel : BaseModel
    {
        private readonly int[] _numbers;
        private readonly Random _random;
        public int PlayCount { get; private set; }
        public bool IsSolved => Enumerable.Range(0, _numbers.Length - 1)
                                          .All(i => _numbers[i] == i + 1);

        public char[] Numbers => Enumerable.Range(0, _numbers.Length)
                                           .Select(i => this[i])
                                           .ToArray();

        public GameModel(Guid id, int playCount, int[] numbers = null) : base(id)
        {
            PlayCount = playCount;
            _numbers = (int[])numbers.Clone();
        }

        public GameModel(int[] numbers = null)
        {
            _random = new Random();
            if (numbers != null)
            {
                _numbers = numbers.Select(n => n).ToArray();
            }
            else
            {
                _numbers = Enumerable.Range(0, 9).ToArray();
                Shuffle();
            }
        }

        public char this[int i] => _numbers[i].ToString().Replace('0', ' ')[0];

        public bool Play(int index)
        {
            var blankNeighbourIndex = GetBlankNeighbourIndex(index);
            if (blankNeighbourIndex == null) return false;
            Swap(index, blankNeighbourIndex.Value);
            PlayCount++;
            return true;
        }

        private int? GetBlankNeighbourIndex(int index)
        {
            var row = index / 3;
            var col = index % 3;
            if (col < 2 && IsBlank(index + 1)) return index + 1;
            if (col > 0 && IsBlank(index - 1)) return index - 1;
            if (row < 2 && IsBlank(index + 3)) return index + 3;
            if (row > 0 && IsBlank(index - 3)) return index - 3;
            return null;
        }

        private bool IsBlank(int i)
        {
            return i >= 0 && i < _numbers.Length && _numbers[i] == 0;
        }

        public void Shuffle()
        {
            var n = _numbers.Length - 1;
            while (n > 1) Swap(n, _random.Next(n--));
            PlayCount = 0;
        }

        private void Swap(int n, int k)
        {
            var temp = _numbers[n];
            _numbers[n] = _numbers[k];
            _numbers[k] = temp;
        }

    }
}
