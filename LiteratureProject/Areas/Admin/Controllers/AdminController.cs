using LiteratureProject.Areas.Admin.Models;
using LiteratureProject.Extensions;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LiteratureProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
       

        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public async Task<IActionResult> AssignRoleToUser()
        {
            var users = await _userManager.Users.ToListAsync(); 
            var roles = await _roleManager.Roles.ToListAsync();

           
            var model = new AssignRoleViewModel
            {
                Users = users.Select(u => new SelectListItem
                {
                    Value = u.Id, 
                    Text = u.UserName 
                }).ToList(),
                Roles = roles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name 
                }).ToList()
            };

            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.SelectedUserId);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await _roleManager.RoleExistsAsync(model.SelectedRole);
            if (!roleExists)
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(model.SelectedRole));
                if (!roleResult.Succeeded)
                {
                    return BadRequest("Role creation failed.");
                }
            }

            var result = await _userManager.AddToRoleAsync(user, model.SelectedRole);
            if (result.Succeeded)
            {
                return Ok($"Role {model.SelectedRole} assigned successfully.");
            }

            return BadRequest("Role assignment failed.");
        }
        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            
            return View();
        }
    }
}
