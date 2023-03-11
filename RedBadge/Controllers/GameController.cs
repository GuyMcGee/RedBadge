using Microsoft.AspNetCore.Mvc;

namespace RedBadge.Controllers
{
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
