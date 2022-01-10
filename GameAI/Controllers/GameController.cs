using System.Net;
using GameAI.Game.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly GameService _gameService;

        public GameController(ILogger<GameController> logger, GameService gameService)
        {
            _gameService = gameService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult MakeTurn(int cardId)
        {
            var result = _gameService.MakeTurn(cardId);
            return Ok(result);
        }
    }
}
