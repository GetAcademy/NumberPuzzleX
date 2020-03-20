using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberPuzzleX.Infrastructure.API.ViewModel
{
    public class GameViewModel
    {
        public string Id { get; }
        public int PlayCount { get; set; }
        public bool IsSolved { get; set; }
        public char[] Numbers { get; set; }

        public GameViewModel(string id, int playCount, bool isSolved, char[] numbers)
        {
            Id = id;
            PlayCount = playCount;
            IsSolved = isSolved;
            Numbers = numbers;
        }
    }
}
