using System;
using System.Collections.Generic;
using System.Text;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Services;

namespace _40_NumberPuzzleX.Core.Application.Services
{
    public class GameService
    {
        private readonly IGameModelRepository _repository;

        public GameService(IGameModelRepository repository)
        {
            _repository = repository;
        }

        public GameModel Play(int index, Guid gameId)
        {
            var gameModel = _repository.Read(gameId);
            var hasPlayed = gameModel.Play(index);
            _repository.Update(gameModel);
            return gameModel;
        }

        public GameModel StartGame()
        {
            var gameModel = new GameModel();
            _repository.Create(gameModel);
            return gameModel;
        }

        public GameModel Read(Guid gameId)
        {
            return _repository.Read(gameId);
        }
    }
}
