using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;
using RedBadge.Services.Rank;

namespace RedBadge.Controllers
{
        [Route("[controller]")]
        public class RankController : Controller
        {
            private IRankService _rankService;

            public RankController(IRankService rankService)
            {
                _rankService = rankService;
            }

            [HttpGet]
            public async Task<IActionResult> Index()
            {
                return View(await _rankService.GetAllRanksAsync());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> Details(int rankId)
            {
                return View(await _rankService.GetRankByIdAsync(rankId));
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
            public async Task<IActionResult> Post(RankCreate model)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (await _rankService.CreateRankAsync(model))
                    return RedirectToAction(nameof(Index));
                else
                    return View(model);
            }

            [HttpGet]
            [Route("Edit/{id}")]
            public async Task<IActionResult> Edit(int rankId)
            {
                var rank = await _rankService.GetRankByIdAsync(rankId);
                var rankEdit = new RankEdit
                {
                    Id = rank.Id,
                    RankName = rank.RankName,
                };
                return View(rankEdit);
            }

            [HttpPost]
            [Route("Edit/{id}")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int rankId, RankEdit rankModel)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (await _rankService.UpdateRankAsync(rankId, rankModel))
                    return RedirectToAction(nameof(Index));
                else
                    return View(rankModel);
            }

            [HttpGet]
            [Route("Delete/{id}")]
            public async Task<IActionResult> Delete(int? rankId)
            {
                var rank = await _rankService.GetRankByIdAsync(rankId.Value);
                return View(rank);
            }

            [HttpGet]
            [Route("Delete/{id}")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int rankId)
            {
                var isSuccessful = await _rankService.DeleteRankAsync(rankId);
                if (isSuccessful)
                    return RedirectToAction(nameof(Index));
                else
                    return UnprocessableEntity();
            }
        }
}
