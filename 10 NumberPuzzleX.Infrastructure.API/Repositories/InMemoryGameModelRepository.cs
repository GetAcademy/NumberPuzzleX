using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Services;

namespace _10_NumberPuzzleX.Infrastructure.API.InMemoryDb
{
    public class InMemoryGameModelRepository : IGameModelRepository
    {
        private readonly Dictionary<Guid,GameModel> _gameModels;

        public InMemoryGameModelRepository()
        {
            _gameModels = new Dictionary<Guid, GameModel>();
        }
        public void Create(GameModel gameModel)
        {
            _gameModels.Add(gameModel.Id, gameModel);
        }

        public GameModel Read(Guid id)
        {
            return _gameModels[id];
        }

        public void Update(GameModel gameModel)
        {
            _gameModels[gameModel.Id] = gameModel;
        }
    }
}
