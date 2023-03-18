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
        public async Task<IActionResult> Details(int id)
        {
            return View(await _playerService.GetPlayerByIdAsync(id));
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
        public async Task<IActionResult> Edit(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);
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
        public async Task<IActionResult> Edit(int id, PlayerEdit playerModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _playerService.UpdatePlayerAsync(id, playerModel))
                return RedirectToAction(nameof(Index));
            else
                return View(playerModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id.Value);
            return View(player);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _playerService.DeletePlayerAsync(id);
            if(isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}