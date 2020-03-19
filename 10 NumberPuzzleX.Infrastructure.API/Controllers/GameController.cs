using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _10_NumberPuzzleX.Infrastructure.API.ViewModel;
using _40_NumberPuzzleX.Core.Application.Services;
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
        public GameModel Start()
        {
            return _gameService.StartGame();
        }

        [HttpGet("gameId")]
        public GameModel Read(string gameId)
        {
            var guid = new Guid(gameId);
            return _gameService.Read(guid);
        }

        [HttpPut]
        public GameModel Play([FromBody]PlayViewModel playViewModel)
        {
            var guid = new Guid(playViewModel.GameId);
            return _gameService.Play(playViewModel.Index, guid);
        }
    }
}
