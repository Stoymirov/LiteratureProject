using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LiteratureProject.Controllers
{
    public class BulgarianController : Controller
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

        var id =  await  service.AddDeckAsync(model,User.Id());
            return View(nameof(MyDecks));
        }
        public async Task<IActionResult> All()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyDeck(int id)
        {
            var model = await service.GetDeckByDeckIdAsync(id);

            return View();
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
            
            var id = await service.AddProblemAsync(model);
           
            return View(nameof(MyDeck), new {id=model.DeckOfProblemsId});
        }
    }
}
