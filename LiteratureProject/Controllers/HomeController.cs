using LiteratureProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LiteratureProject.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            //if (User.IsInRole("Admin"))
            //{
            //    return RedirectToAction("Dashboard", "Admin", new { area = "Admin" });
            //}
            if (User.Identity?.IsAuthenticated == true)
            {
               
                return RedirectToAction(nameof(MainPage));
            }

           
            return View();
        }
        public IActionResult MainPage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
           
            
                if (statusCode == 404)
                {
                    return View("Error404");
                }

                if (statusCode == 500)
                {
                    return View("Error500");
                }
                return View();

            
        }
    }
}
