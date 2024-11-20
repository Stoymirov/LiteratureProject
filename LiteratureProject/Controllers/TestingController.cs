using LiteratureProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureProject.Controllers
{
    public class TestingController : BaseController
    {
        private ITestingService service;
        public TestingController(ITestingService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ChooseDeck()
        {
            var extractAllDecks = await service.GetAllDecksAsync();
            
            return View(extractAllDecks);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDeck(int deckId)
        {
            var extractDeckById = await service.GetDeckByIdAsync(deckId);
            //if (extractDeckById == null)
            //{
            //    TempData["Error"] = "Deck not found.";
            //    return RedirectToAction("ChooseDeck");
            //}
            return View(extractDeckById);
        }
    }
}
