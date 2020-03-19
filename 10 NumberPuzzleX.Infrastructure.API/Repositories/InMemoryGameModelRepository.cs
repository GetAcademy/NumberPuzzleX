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
        private readonly List<GameModel> _gameModels;

        public InMemoryGameModelRepository()
        {
            _gameModels = new List<GameModel>();
        }
        public void Create(GameModel gameModel)
        {
            _gameModels.Add(gameModel);
        }

        public GameModel Read(Guid id)
        {
            return _gameModels.Find(gm => gm.Id == id);
        }

        public void Update(GameModel gameModel)
        {
            var index = _gameModels.FindIndex(gm => gm.Id == gameModel.Id);
            _gameModels[index] = gameModel;
        }
    }
}
