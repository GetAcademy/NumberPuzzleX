using System;
using System.Threading.Tasks;
using NumberPuzzleX.Core.Domain.Model;

namespace NumberPuzzleX.Core.Domain.Service
{
    public interface IGameModelRepository
    {
        Task<int> Create(GameModel gameModel);
        Task<GameModel> Read(Guid id);
        Task<int> Update(GameModel gameModel);
    }
}
