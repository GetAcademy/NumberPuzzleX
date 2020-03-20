using System;
using System.Collections.Generic;
using System.Text;

namespace _14_NumberPuzzleX.Infrastructure.DataAccess.Model
{
    class GameModel
    {
        public Guid Id { get; set;  }
        public int PlayCount { get; set; }
        public string Numbers { get; set; }
    }
}
