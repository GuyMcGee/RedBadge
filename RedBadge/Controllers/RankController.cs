using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;
using RedBadge.Services.Rank;

namespace RedBadge.Controllers
{
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

            [HttpGet]
            public async Task<IActionResult> Details(int id)
            {
                return View(await _rankService.GetRankByIdAsync(id));
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
            public async Task<IActionResult> Edit(int id)
            {
                var rank = await _rankService.GetRankByIdAsync(id);
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
            public async Task<IActionResult> Edit(int id, RankEdit rankModel)
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (await _rankService.UpdateRankAsync(id, rankModel))
                    return RedirectToAction(nameof(Index));
                else
                    return View(rankModel);
            }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            var rank = await _rankService.GetRankByIdAsync(id.Value);
            return View(rank);
        }

        [HttpPost]
        //[Route("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _rankService.DeleteRankAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
