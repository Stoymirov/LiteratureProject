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
                    // Check if a new file is uploaded
                    if (model.ProfilePicture != null && model.ProfilePicture.Length > 0)
                    {
                        try
                        {
                            // Upload the file to Google Cloud Storage
                            using var stream = model.ProfilePicture.OpenReadStream();
                            var profilePictureUrl = await _gcsService.UploadFileAsync(stream, model.ProfilePicture.FileName,"image/jpeg");

                            // Update the model with the uploaded file URL
                            model.ProfilePictureUrl = profilePictureUrl;
                        }
                        catch (Exception ex)
                        {
                            // Log and handle the exception appropriately
                            ModelState.AddModelError("", "Failed to upload the file. Please try again.");
                            Console.WriteLine(ex.Message); // Replace with your logging solution
                            return View(model);
                        }
                    }

                    // Update the user information using the service
                    var updateResult = await service.EditInformationAsync(model);
                    if (updateResult)
                    {
                        // Redirect to the Index or desired page upon success
                        return RedirectToAction(nameof(Index));
                    }

                    // If service fails, show an error message
                    ModelState.AddModelError("", "Failed to update user information.");
                }

                // Log all errors to debug issues in the ModelState
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage); // Replace with appropriate logging
                }

                // Return to the same view with errors if ModelState is invalid
                return View(model);
            }

    }
}
