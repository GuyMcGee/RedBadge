using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.GameModels;

namespace RedBadge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("Create Game")]
        public async Task<IActionResult> CreateGame([FromBody] GameCreate gameModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameCreateResult = await _gameService.GameCreateAsync(gameModel);
            if(gameCreateResult)
            {
                return Ok("Game was created");
            }
            return BadRequest("Game could not be created");
        }
    }
}
