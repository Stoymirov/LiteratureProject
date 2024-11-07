using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Services
{
    public class BulgarianService : IBulgarianService
    {
        private ApplicationDbContext context;
        public BulgarianService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> AddDeckAsync(DeckFormModel model,string userId)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The provided model cannot be null.");
            }
            var collectionOfQuestions = new List<BulgarianProblem>();
            var deck = new DeckOfBulgarianProblems()
            {
                Id = model.Id,
                CreatedBy = model.CreatedBy,
                Name = model.Name,
                Topic = model.SelectedTopic,
                BulgarianProblems = collectionOfQuestions,
                CreatedById =userId
            };
            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();
            return deck.Id;
        }

        public async Task<int> AddProblemAsync(ProblemFormModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "The provided model cannot be null.");
            }

            var problem = new BulgarianProblem()
            {
                Id = model.Id,
                Answer1 = model.Answer1,
                Answer2 = model.Answer2,
                Answer3 = model.Answer3,
                Answer4 = model.Answer4,
                DeckOfProblemsId = model.DeckOfProblemsId,
                Explanation = model.Explanation,
                IsAnswer1Correct = model.IsAnswer1Correct,
                IsAnswer2Correct = model.IsAnswer2Correct,
                IsAnswer3Correct = model.IsAnswer3Correct,
                IsAnswer4Correct = model.IsAnswer4Correct

            };
            await context.BulgarianProblems.AddAsync(problem);
            await context.SaveChangesAsync();
            return problem.Id;

        }

        public async Task<IEnumerable<DeckOfBulgarianProblems>> GetAllDecksByUserId(string userId)
        {
            var models = await context.DecksOfBulgarianProblems.Where(x => x.CreatedById == userId).ToListAsync();
            return models;
        }

        public async Task<DeckOfBulgarianProblems> GetDeckByDeckIdAsync(int deckId)
        {
           var model = await context.DecksOfBulgarianProblems.Where(x=>x.Id ==deckId)
                .Include(x=>x.BulgarianProblems)
                .FirstOrDefaultAsync();
            return model;
        }
    }
}
