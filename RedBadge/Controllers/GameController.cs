using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.GameModels;
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

        [HttpGet]
        [Route("Post")]
        public async Task<IActionResult> Post()
        {
            return View();
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(GameCreate game)
        {
            if(!ModelState.IsValid)return BadRequest(ModelState);
            if(await _gameService.CreateGameAsync(game))
                return RedirectToAction(nameof(Index));
            else
                return View(game);
        }
    }
}
