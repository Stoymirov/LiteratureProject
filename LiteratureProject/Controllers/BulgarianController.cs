using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using Microsoft.AspNetCore.Mvc;

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

        var id =  await  service.AddDeckAsync(model);
            return View(nameof(Mine));
        }
        public async Task<IActionResult> All()
        {
            return View();
        }
        public async Task<IActionResult> Mine()
        {
            return View();
        }
    }
}
