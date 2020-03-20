﻿using System;
using System.Threading.Tasks;
using _40_NumberPuzzleX.Core.Domain.Model;

namespace _40_NumberPuzzleX.Core.Domain.Service
{
    public interface IGameModelRepository
    {
        Task<int> Create(GameModel gameModel);
        Task<GameModel> Read(Guid id);
        Task<int> Update(GameModel gameModel);
    }
}
