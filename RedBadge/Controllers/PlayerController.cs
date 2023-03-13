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

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _playerService.GetAllPlayersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int playerId)
        {
            return View(await _playerService.GetPlayerByIdAsync(playerId));
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
        public async Task<IActionResult> Post(PlayerCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _playerService.CreatePlayerAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int playerId)
        {
            var player = await _playerService.GetPlayerByIdAsync(playerId);
            var playerEdit = new PlayerEdit
            {
                Id = player.Id,
                Name = player.Name,
            };
            return View(playerEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int playerId, PlayerEdit playerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _playerService.UpdatePlayerAsync(playerId, playerModel))
                return RedirectToAction(nameof(Index));
            else
                return View(playerModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? playerId)
        {
            var player = await _playerService.GetPlayerByIdAsync(playerId.Value);
            return View(player);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int playerId)
        {
            var isSuccessful = await _playerService.DeletePlayerAsync(playerId);
            if(isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}

