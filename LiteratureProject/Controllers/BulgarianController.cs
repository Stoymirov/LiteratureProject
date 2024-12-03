using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.ProjectModel;

namespace LiteratureProject.Controllers
{
    public class BulgarianController : BaseController
    {
        private IBulgarianService service;
        public BulgarianController(IBulgarianService service)
        {
            this.service = service;   
        }
        public IActionResult Index()
        {
            return View();
        }    

        [HttpGet]
        public async Task<IActionResult> AddDeck()
        {

            var model = new DeckFormModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeck(DeckFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var id =  await  service.AddDeckAsync(model,User.Id());
            return RedirectToAction(nameof(MyDecks));
        }
        public async Task<IActionResult> All()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyDeck(int id)
        {
            var model = await service.GetDeckByDeckIdAsync(id);

            var displayModel = new DeckDisplayModel()
            {
                CreatedBy = model.CreatedBy,
                Id = model.Id,
                Name = model.Name,
                Topic = model.Topic,
                
            };
            return View(displayModel);
        }
        [HttpGet]
        public async Task<IActionResult> MyDecks()
        {
            string userId = User.Id();

            var decks = await service.GetAllDecksByUserId(userId);

            var model = decks.Select(x => new DeckDisplayModel
            {
                CreatedBy = x.CreatedBy,
                Id = x.Id,
                Name = x.Name,
                Topic = x.Topic
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> AddProblem()
        {
            string userId = User.Id();
            var myDecks = await service.GetAllDecksByUserId(userId);

            var model = new ProblemFormModel
            {
                DeckOptions = myDecks.Select(deck => new SelectListItem
                {
                    Value = deck.Id.ToString(),
                    Text = deck.Name
                }).ToList()
            };


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProblem(ProblemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                string userId = User.Id();
                var myDecks = await service.GetAllDecksByUserId(userId);

                model.DeckOptions = myDecks.Select(deck => new SelectListItem
                {
                    Value = deck.Id.ToString(),
                    Text = deck.Name
                }).ToList();

                return View(model); 
            }
            var id = await service.AddProblemAsync(model);

            return RedirectToAction(nameof(MyDeck), new { id = model.DeckOfProblemsId });
        }
        [HttpGet]
        public async Task<IActionResult> ProblemsWithDeckId(int deckId, int pageNumber =1)
        {
            var problems =await service.GetProblemsByDeckIdAsync(deckId);
            var totalProblems = problems.Count();

            if (pageNumber < 1) pageNumber = 1;
            if (pageNumber > totalProblems) pageNumber = totalProblems;

            var problem = problems
                .Skip((pageNumber - 1)) 
                .Take(1)               
                .FirstOrDefault();

            var viewModel = new SingleProblemDisplayModel
            {
                Problem = problem,
                CurrentPage = pageNumber,
                TotalPages = totalProblems,
                DeckId = deckId
            };

            return View(viewModel);
           
        }
        [HttpGet]
        public async Task<IActionResult> EditProblem(int problemId)
        {
            string userId = User.Id();
            var myDecks = await service.GetAllDecksByUserId(userId);

            var problem = await service.GetProblemByIdAsync(problemId);
            problem.DeckOptions = myDecks.Select(deck => new SelectListItem
            {
                Value = deck.Id.ToString(),
                Text = deck.Name
            }).ToList();
            
            return View(problem);
        }
        [HttpPost]
        public async Task<IActionResult> EditProblem(ProblemFormModel model)
        {
            if (!ModelState.IsValid)
            {
                string userId = User.Id();
                var myDecks = await service.GetAllDecksByUserId(userId);

                model.DeckOptions = myDecks.Select(deck => new SelectListItem
                {
                    Value = deck.Id.ToString(),
                    Text = deck.Name
                }).ToList();

                return View(model); 
            }
            var id = await service.EditProblemAsync(model);
            return RedirectToAction(nameof(MyDeck), new { id =model.DeckOfProblemsId });
        }
        
    }
}
