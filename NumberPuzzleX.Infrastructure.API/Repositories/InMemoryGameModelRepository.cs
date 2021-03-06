﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NumberPuzzleX.Core.Domain.Model;
using NumberPuzzleX.Core.Domain.Service;

namespace NumberPuzzleX.Infrastructure.API.Repositories
{
    public class InMemoryGameModelRepository : IGameModelRepository
    {
        private readonly Dictionary<Guid,GameModel> _gameModels;

        public InMemoryGameModelRepository()
        {
            _gameModels = new Dictionary<Guid, GameModel>();
        }

        public Task<int> Create(GameModel gameModel)
        {
            return Task.Run(() =>
            {
                _gameModels.Add(gameModel.Id, gameModel);
                return 1;
            });
        }

        public Task<GameModel> Read(Guid id)
        {
            return Task.Run(()=> _gameModels[id]);
        }

        public Task<int> Update(GameModel gameModel)
        {
            return Task.Run(()=>
            {
                _gameModels[gameModel.Id] = gameModel;
                return 1;
            });
        }
    }
}
