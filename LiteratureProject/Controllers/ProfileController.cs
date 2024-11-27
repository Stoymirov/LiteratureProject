using Microsoft.AspNetCore.Mvc;

namespace LiteratureProject.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public Task<IActionResult> Edit()
        {

        }
    }
}
