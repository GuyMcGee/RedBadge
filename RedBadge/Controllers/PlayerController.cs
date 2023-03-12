using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.PlayerModels;
using RedBadge.Services.Player;

namespace RedBadge.Controllers
{
    [Route("[controller]")]
    public class PlayerController : Controller
    {
        private IPlayerService _playerService;
        
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _playerService.GetAllPlayers());
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _gameService.GetAllGamesAsync());
    }

    [HttpPost]
    [Route("Post")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Post(PlayerCreate game)
    {
        if (!ModelState.IsValid) return BadRequest(game);
        if (await _gameService.CreateGameAsync(game))
            return RedirectToAction(nameof(Index));
        else
            return View(game);
    }
}
}
