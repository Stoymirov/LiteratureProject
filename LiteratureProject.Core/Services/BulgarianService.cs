using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
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

        public async Task<int> AddDeckAsync(DeckFormModel model)
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
                BulgarianProblems = collectionOfQuestions
            };
            await context.DecksOfBulgarianProblems.AddAsync(deck);
            await context.SaveChangesAsync();
            return deck.Id;
        }
    }
}
