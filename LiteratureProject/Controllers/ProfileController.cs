using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.ProfileModels;
using LiteratureProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Storage.V1;
using LiteratureProject.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LiteratureProject.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly GCSService _gcsService;


        private IProfileService service;
        public ProfileController(IProfileService service, GCSService gcsService)
        {
            this.service = service;
            _gcsService = gcsService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await service.GiveUserProfileViewModel(User.Id());
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = await service.GiveUserProfileViewModel(User.Id());
            return View(model);
        }
        [HttpPost]
   
            public async Task<IActionResult> Edit(UserProfileViewModel model)
            {
                if (ModelState.IsValid)
                {
                   
                    if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                    {
                        try
                        {
                            
                            using var stream = model.ProfilePicture.OpenReadStream();
                            var profilePictureUrl = await _gcsService.UploadFileAsync(stream, model.ProfilePicture.FileName,"image/jpeg");

                            
                            model.ProfilePictureUrl = profilePictureUrl;
                        }
                        catch (Exception ex)
                        {
                          
                            ModelState.AddModelError("", "Failed to upload the file. Please try again.");
                            Console.WriteLine(ex.Message); 
                            return View(model);
                        }
                    }

                    
                    var updateResult = await service.EditInformationAsync(model);
                    if (updateResult)
                    {
                        
                        return RedirectToAction(nameof(Index));
                    }

                    
                    ModelState.AddModelError("","Failed to update user information.");
                }

              
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); 
                }

               
                return View(model);
            }

    }
}
