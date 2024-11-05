using LiteratureProject.Core.Models.BulgarianModels;
using Microsoft.AspNetCore.Mvc;

namespace LiteratureProject.Controllers
{
    public class BulgarianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public Task<IActionResult> AddDeck()
        {
            var originalModel = 
            var model = new DeckFormModel()
            {

            }
            return View();
        }
    }
}
