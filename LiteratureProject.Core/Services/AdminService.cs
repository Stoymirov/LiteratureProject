using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.AdminModels;
using LiteratureProject.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AdminDashboardViewModel> GetDashboardStatisticsAsync()
        {
            var viewModel = new AdminDashboardViewModel
            {
                UserCount = await _context.Users.CountAsync(),
                DeckCount = await _context.DecksOfBulgarianProblems.CountAsync(),
                LiteratureWorksCount = await _context.LiteratureWorks.CountAsync(),
                AuthorsCount = await _context.Authors.CountAsync()
               
            };

            return viewModel;
        }
    }
}
