using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.OccasionModels;
using RedBadge.Services.Occasion;
using RedBadge.Services.Player;

namespace RedBadge.Controllers
{
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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _occasionService.GetOccasionByIdAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> Post()
        {
            return View();
        }


        [HttpPost]
        [ActionName("Post")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostOccasion(OccasionCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _occasionService.CreateOccasionAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        //[Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var occasion = await _occasionService.GetOccasionByIdAsync(id);
            var occasionEdit = new OccasionEdit
            {
                Id = occasion.Id,
                Name = occasion.Name,
            };
            return View(occasionEdit);
        }

        [HttpPost]
        //[Route("Edit/{id}")]
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
        public async Task<IActionResult> Delete(int? id)
        {
            var occasion = await _occasionService.GetOccasionByIdAsync(id.Value);
            return View(occasion);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccessful = await _occasionService.DeleteOccasionAsync(id);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
