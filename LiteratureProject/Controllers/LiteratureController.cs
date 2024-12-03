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
using Microsoft.EntityFrameworkCore.Migrations.Internal;

namespace LiteratureProject.Controllers
{
    public class LiteratureController : BaseController
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
            model.TeacherId = User.Id();
            return View(model);
        }
        [HttpPost]

        public async Task<IActionResult> Add(LiteratureWorkViewModel model)
        {
            
            if (await service.AuthorExistsAsync(model.AuthorId) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Author does not exist.");
            }

           
            if (string.IsNullOrWhiteSpace(model.Name) || model.Name.Length < 3)
            {
                ModelState.AddModelError(nameof(model.Name), "The Name must be at least 3 characters long.");
            }

            
            //if (!ModelState.IsValid)
            //{
                
            //    foreach (var state in ModelState)
            //    {
            //        var key = state.Key;
            //        var errors = state.Value.Errors;
            //        foreach (var error in errors)
            //        {
            //            Console.WriteLine($"Validation Error: Key={key}, Error={error.ErrorMessage}");
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

            //here i do not do the modelValidation because the analysis parts are not yet created and therefore the modelState is always invaid

           
            string userId = User.Id();
            int newLiteratureWork = await service.CreateAsync(model, userId);

            return RedirectToAction(nameof(Mine));
        }



        public async Task<IActionResult> All(string searchTerm)
        {
            var allWorks = await service.GetAllWorksAsync();
            if (!string.IsNullOrEmpty(searchTerm)){
                allWorks = allWorks.Where(w =>
         (w.Name != null && w.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
         (w.AuthorName != null && w.AuthorName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
         (w.TeacherName != null && w.TeacherName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)));
            }
            ViewData["SearchTerm"] = searchTerm;
            return View(allWorks);
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
        [HttpGet]
        public async Task<IActionResult> Details(int id,int part = 1)
        {

            var model = await service.GetWorkByIdAsync(id, part);

            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(!await service.WorkExistsAsync(id))
            {
                return BadRequest();
            }
            var model =await service.GetLiteratureWorkViewModelById(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit( LiteratureWorkViewModel model)
        {
            if (await service.AuthorExistsAsync(model.AuthorId) == false)
            {
                ModelState.AddModelError(nameof(model.AuthorId), "Author does not exist");
            }

            string userId = User.Id();

            var literatureModel = await service.GetLiteratureWorkNormalByIdAsync(model.Id);
            if (literatureModel == null)
            {
                return NotFound(); 
            }

          await service.EditAsync(model);
            return RedirectToAction(nameof(Mine));
          
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int workId)
        {
            var model = await service.GetLiteratureWorkNormalByIdAsync(workId);
            var viewModel = new LiteratureWorkDisplayViewModel()
            {
                
                Id = model.Id,
                Name = model.Name
               
            };
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var success = await service.DeleteWorkAsync(id);
            if (success)
            {
                return RedirectToAction(nameof(Mine));
            }
            return View(); 
        }
    }
}
