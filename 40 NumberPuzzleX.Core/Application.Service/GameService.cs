using System;
using System.Threading.Tasks;
using _40_NumberPuzzleX.Core.Domain.Model;
using _40_NumberPuzzleX.Core.Domain.Service;

namespace _40_NumberPuzzleX.Core.Application.Service
{
    public class GameService
    {
        private readonly IGameModelRepository _repository;

        public GameService(IGameModelRepository repository)
        {
            _repository = repository;
        }

        public async Task<GameModel> Play(int index, Guid gameId)
        {
            var gameModel = await _repository.Read(gameId);
            var hasPlayed = gameModel.Play(index);
            await _repository.Update(gameModel);
            return gameModel;
        }

        public async Task<GameModel> StartGame()
        {
            var gameModel = new GameModel();
            await _repository.Create(gameModel);
            return gameModel;
        }

        public async Task<GameModel> Read(Guid gameId)
        {
            return await _repository.Read(gameId);
        }
    }
}
