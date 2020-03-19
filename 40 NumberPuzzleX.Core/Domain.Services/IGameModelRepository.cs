using System;
using System.Collections.Generic;
using System.Text;
using _40_NumberPuzzleX.Core.Domain.Model;

namespace _40_NumberPuzzleX.Core.Domain.Services
{
    public interface IGameModelRepository
    {
        void Create(GameModel gameModel);
        GameModel Read(Guid id);
        void Update(GameModel gameModel);
    }
}
