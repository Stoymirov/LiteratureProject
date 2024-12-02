using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.ProfileModels;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Services
{
    public class ProfileService : IProfileService
    {
        private ApplicationDbContext _context;
        private  UserManager<ApplicationUser> _userManager;
        private  IServiceProvider _serviceProvider;
        public ProfileService(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
        {
            _context = context;
            _userManager = userManager;
            _serviceProvider = serviceProvider; 
        }

        public async Task<UserProfileViewModel> GiveUserProfileViewModel(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);

            var role = roles.FirstOrDefault() ?? "No Role Assigned";

            return new UserProfileViewModel
            {
                FullName = user.FirstName + " " + user.LastName,
                Bio = user.Bio,
                Id = user.Id,
                Location = user.Location,
                ProfilePictureUrl = user.ImageUrl,
                Role = role
            };
        }

        public async Task<bool> EditInformationAsync(UserProfileViewModel model)
        {
            using (var scope = _serviceProvider.CreateScope()) // Manually creating a scope
            {
                var scopedContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var scopedUserManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                ApplicationUser user = await scopedUserManager.FindByIdAsync(model.Id);

                if (user == null)
                {
                    throw new InvalidOperationException("User not found");
                }

                user.Bio = model.Bio;
                user.Location = model.Location;
                user.ImageUrl = model.ProfilePictureUrl;

                try
                {
                    var result = await scopedUserManager.UpdateAsync(user);
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
                return true;
            }

        }
    }
    }
