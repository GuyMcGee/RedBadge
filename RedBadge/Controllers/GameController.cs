using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RedBadge.Models.GameModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Services.Game;
using RedBadge.Services.Player;

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

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _gameService.GetGameByIdAsync(id));
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

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            var gameEdit = new GameEdit
            {
                Id = game.Id,
                Name = game.Name,
            };
            return View(gameEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GameEdit gameModel)
        {
            if (id!=gameModel.Id) return BadRequest("Invalid ID");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _gameService.UpdateGameAsync(id, gameModel))
                return RedirectToAction(nameof(Index));
            else
                return View(gameModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var game = await _gameService.GetGameByIdAsync(id.Value);
            return View(game);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _gameService.DeleteGameAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
