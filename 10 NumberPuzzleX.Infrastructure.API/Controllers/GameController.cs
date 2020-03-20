using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _10_NumberPuzzleX.Infrastructure.API.ViewModel;
using _40_NumberPuzzleX.Core.Application.Service;
using _40_NumberPuzzleX.Core.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NumberPuzzleX.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _gameService;

        public GameController(GameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<GameViewModel> Start()
        {
            var game = await _gameService.StartGame();
            return MapToViewModel(game);
        }

        [HttpGet("{gameId}")]
        public async Task<GameViewModel> Read(string gameId)
        {
            var guid = new Guid(gameId);
            var game = await _gameService.Read(guid);
            return MapToViewModel(game);
        }

        [HttpPut]
        public async Task<GameViewModel> Play(PlayViewModel play)
        {
            var guid = new Guid(play.GameId);
            var game = await _gameService.Play(play.Index, guid);
            return MapToViewModel(game);
        }

        private static GameViewModel MapToViewModel(GameModel game)
        {
            // Finnes ferdige pakker for dette, f.eks. AutoMapper (NuGet)
            return new GameViewModel(game.Id.ToString(), game.PlayCount, game.IsSolved, game.Numbers);
        }
    }
}
