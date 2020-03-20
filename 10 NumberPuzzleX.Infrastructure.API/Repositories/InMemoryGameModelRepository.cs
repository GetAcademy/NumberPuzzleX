using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Service;

namespace _10_NumberPuzzleX.Infrastructure.API.InMemoryDb
{
    public class InMemoryGameModelRepository : IGameModelRepository
    {
        private readonly Dictionary<Guid,GameModel> _gameModels;

        public InMemoryGameModelRepository()
        {
            _gameModels = new Dictionary<Guid, GameModel>();
        }

        public Task Create(GameModel gameModel)
        {
            return Task.Run(() => _gameModels.Add(gameModel.Id, gameModel));
        }

        public Task<GameModel> Read(Guid id)
        {
            return Task.Run(()=> _gameModels[id]);
        }

        public Task Update(GameModel gameModel)
        {
            return Task.Run(()=>_gameModels[gameModel.Id] = gameModel);
        }
    }
}
