using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.ProfileModels;
using LiteratureProject.Extensions;
using Microsoft.AspNetCore.Mvc;
using Google.Cloud.Storage.V1;
using LiteratureProject.Core.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace LiteratureProject.Controllers
{
    public class ProfileController : Controller
    {
        private readonly GCSService _gcsService; // The Google Cloud Storage service class


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

                if (model.ProfilePicture != null)
                {

                    var profilePictureUrl = await _gcsService.UploadFileAsync(model.ProfilePicture);
                    model.ProfilePictureUrl = profilePictureUrl;
                }

                var returning = service.EditInformationAsync(model);

                return RedirectToAction(nameof(Index));
            }
            foreach(var error in ModelState.Values.SelectMany(v => v.Errors))
    {
                // Log each error (this could be to a file, a logger, or just output to the console)
                Console.WriteLine(error.ErrorMessage);  // You can replace this with your logging solution
            }
            return View();

        }
    }
}
