using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Data;
using Microsoft.EntityFrameworkCore;
namespace LiteratureProject.Core.Services
{
    public class TestingService : ITestingService
    {
        private ApplicationDbContext context;
        public TestingService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<DeckDisplayModel>> GetAllDecksAsync()
        {
            var allDecks = await context.DecksOfBulgarianProblems.Select(x => new DeckDisplayModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedBy = x.CreatedBy,
                Topic = x.Topic
            })
                  .ToListAsync();

            return allDecks;
        }
    }
}
