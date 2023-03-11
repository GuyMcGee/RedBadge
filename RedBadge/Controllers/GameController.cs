using Microsoft.AspNetCore.Mvc;
using RedBadge.Services.Game;

namespace RedBadge.Controllers
{
    [Route("[controller]")]
    public class GameController : Controller
    {
        private IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _gameService.GetAllGamesAsync());
        }
    }
}
