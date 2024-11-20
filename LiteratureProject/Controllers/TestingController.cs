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
        public IActionResult ConfirmDeck(int deckId)
        {
            // Do something with the selected deckId (e.g., save, process, etc.)
            TempData["Message"] = $"Deck with ID {deckId} selected.";
            return RedirectToAction("ChooseDeck");
        }
    }
}
