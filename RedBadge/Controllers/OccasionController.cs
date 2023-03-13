using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.OccasionModels;
using RedBadge.Services.Occasion;

namespace RedBadge.Controllers
{
    [Route("[controller]")]
    public class OccasionController : Controller
    {
        private IOccasionService _occasionService;
        
        public OccasionController(IOccasionService occasionService)
        {
            _occasionService = occasionService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _occasionService.GetAllOccasionsAsync());
        }

        [HttpPost]
        [Route("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post(OccasionCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _occasionService.CreateOccasionAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int occasionId)
        {
            var occasion = await _occasionService.GetOccasionByIdAsync(occasionId);
            var occasionEdit = new OccasionEdit
            {
                Id = occasion.Id,
                Name = occasion.Name,
            };
            return View(occasionEdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int occasionId, OccasionEdit occasionModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _occasionService.UpdateOccasionAsync(occasionId, occasionModel))
                return RedirectToAction(nameof(Index));
            else
                return View(occasionModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? occasionId)
        {
            var occasion = await _occasionService.GetOccasionByIdAsync(occasionId.Value);
            return View(occasion);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int occasionId)
        {
            var isSuccessful = await _occasionService.DeleteOccasionAsync(occasionId);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
