using LiteratureProject.Models;
using Microsoft.AspNetCore.Mvc;
using LiteratureProject.Core.Services;
using LiteratureProject.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using LiteratureProject.Core.Contracts;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using LiteratureProject;
using LiteratureProject.Core.Models.LiteratureWorkModels;
using LiteratureProject.Extensions;

namespace LiteratureProject.Controllers
{
    public class LiteratureController : Controller
    {
        private ILiteratureWorkService service;
        public LiteratureController(ILiteratureWorkService service)
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
        [HttpPost]
        public async Task<IActionResult> Add(LiteratureWorkViewModel model)
        {
            if (await service.AuthorExistsAsync(model.AuthorId) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Author does not exist");
            }

            //if (ModelState.IsValid == false)
            //{
            //    foreach (var key in ModelState.Keys)
            //    {
            //        var state = ModelState[key];
            //        foreach (var error in state.Errors)
            //        {
            //            Console.WriteLine($"Error in '{key}': {error.ErrorMessage}");
            //        }
            //    }

            //    var authors = await service.GetAuthorsAsync();
            //    model.Authors = authors.Select(a => new SelectListItem
            //    {
            //        Value = a.Id.ToString(),
            //        Text = a.Name
            //    }).ToList();

            //    return View(model);
            //}

            string userId = User.Id();

            int newLiteratureWork = await service.CreateAsync(model,userId);
           
            return RedirectToAction(nameof(Mine));
        }
        public async Task<IActionResult> All()
        {
            return View();
        }
        public async Task<IActionResult> Mine()
        {
            var teacherId = User.Id();
            var literatureWorks = await service.AllLiteratureWorksByTeacherId(teacherId); 
            var model = literatureWorks.Select(lw => new LiteratureWorkDisplayViewModel
            {
                Id = lw.Id,
                Name = lw.Name,
                AuthorName = lw.Author.Name,
                TeacherName = lw.TeacherLiteratureWorks.Where(x=>x.Teacher.Id ==teacherId)
                .Select(x=>x.Teacher.FirstName)
                .FirstOrDefault()
            }).ToList();

            return View(model);
        }
    }
}
