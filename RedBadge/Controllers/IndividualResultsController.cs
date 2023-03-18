using Microsoft.AspNetCore.Mvc;
using RedBadge.Models.IndividualResultsModels;
using RedBadge.Services.IndividualResults;

namespace RedBadge.Controllers
{
    [Route("[controller]")]
    public class IndividualResultsController : Controller
    {
        private IIRService _iRService;

        public IndividualResultsController(IIRService iRService)
        {
            _iRService = iRService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _iRService.GetAllIRAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int iRId)
        {
            return View(await _iRService.GetIRByIdAsync(iRId));
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
        public async Task<IActionResult> Post(IRCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _iRService.CreateIRAsync(model))
                return RedirectToAction(nameof(Index));
            else
                return View(model);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int iRId)
        {
            var iR = await _iRService.GetIRByIdAsync(iRId);
            var iREdit = new IREdit
            {
                Id = iR.Id,
                //Name = iR.Player.Name,
            };
            return View(iREdit);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IREdit iRModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (await _iRService.UpdateIRAsync(iRModel))
                return RedirectToAction(nameof(Index));
            else
                return View(iRModel);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? iRId)
        {
            var iR = await _iRService.GetIRByIdAsync(iRId.Value);
            return View(iR);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int iRId)
        {
            var isSuccessful = await _iRService.DeleteIRAsync(iRId);
            if (isSuccessful)
                return RedirectToAction(nameof(Index));
            else
                return UnprocessableEntity();
        }
    }
}
