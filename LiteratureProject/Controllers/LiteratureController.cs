using LiteratureProject.Models;
using Microsoft.AspNetCore.Mvc;
using LiteratureProject.Core.Services;
using LiteratureProject.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace LiteratureProject.Controllers
{
    public class LiteratureController : Controller
    {
        private LiteratureWorkService service;
        public LiteratureController(LiteratureWorkService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public async Task<IActionResult> Add(){

            var authors = await service.GetAuthorsAsync(); 

            var model = new LiteratureWorkViewModel
            {
               
                Authors = authors.Select(a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Name
                }).ToList()
            };

            return View(model);
        }
    }
}
