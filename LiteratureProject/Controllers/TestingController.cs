using LiteratureProject.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using LiteratureProject.Core.Models.TestingModels;
namespace LiteratureProject.Controllers
{
    public class TestingController : BaseController
    {
        private ITestingService service;
        private IBulgarianService bulgarianService;
        public TestingController(ITestingService service, IBulgarianService bulgarianService)
        {
            this.service = service;
            this.bulgarianService = bulgarianService;
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
        [HttpPost]
        public async Task<IActionResult> GiveQuestion(int deckId,int problemNumber = 1,int problemId = 0)
        {
            var question = await service.GetNextQuestionAsync(deckId,problemNumber,problemId);

            ViewData["ProblemNumber"] = problemNumber;
            return View(question);
        }
        [HttpPost]
        public async Task<IActionResult> SeeQuestionResult(int deckId, int problemId, int problemNumber, int selectedAnswer)
        {
            var question = await bulgarianService.GetProblemByIdAsync(problemId);
            bool isCorrect = false;

            if ((selectedAnswer == 1 && question.IsAnswer1Correct) ||
                (selectedAnswer == 2 && question.IsAnswer2Correct) ||
                (selectedAnswer == 3 && question.IsAnswer3Correct) ||
                (selectedAnswer == 4 && question.IsAnswer4Correct))
            {
                isCorrect = true;
            }

            var resultViewModel = new QuestionResultViewModel()
            {
                IsCorrect = isCorrect,
                Explanation = question.Explanation,
                DeckId = deckId,
                NextProblemNumber = problemNumber + 1,
                ProblemId = problemId
            };

            return View(resultViewModel);
        }
    }
}
