using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureProject.Core.Contracts;
using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Core.Models.TestingModels;
using LiteratureProject.Data;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
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

        public async Task<int> GetCountOfProblemsByDeckId(int deckId)
        {
            var deck = await context.DecksOfBulgarianProblems.FirstOrDefaultAsync(x => x.Id == deckId);
            int count = deck.BulgarianProblems.Count();
            return count;
        }

        public async Task<DeckDisplayModel> GetDeckByIdAsync(int id)
        {
            var selectedDeck = await (context.DecksOfBulgarianProblems.FirstOrDefaultAsync(x => x.Id == id));
            return new DeckDisplayModel()
            {
                CreatedBy = selectedDeck.CreatedBy,
                Id = selectedDeck.Id,
                Name = selectedDeck.Name,
                Topic = selectedDeck.Topic
            };
        }
        public async Task<ProblemTestingModel> GetNextQuestionAsync(int deckId, int problemNumber = 1, int problemId = 0)
        {
            var deck = await GetDeckByIdAsync(deckId);

            var bgProblems =await context.BulgarianProblems.Where(x => x.DeckOfProblemsId == deckId).ToListAsync();
            BulgarianProblem problem = null;
            if (problemNumber == 1) {
                problem = bgProblems.OrderBy(x => x.Id).FirstOrDefault(); }
            else
            {
                problem= bgProblems.OrderBy(x=>x.Id).Where(x=>x.Id>problemId).FirstOrDefault();
            }
              
            if(problem == null)
            {
                return null;
            }
            

            var problemDisplayModel = new ProblemTestingModel
            {
                Id = problem.Id,
                Answer1 = problem.Answer1,
                Answer2 = problem.Answer2,
                Answer3 = problem.Answer3,
                Answer4 = problem.Answer4,
                DeckOfProblemsId = problem.DeckOfProblemsId,
                Explanation = problem.Explanation,
                IsAnswer1Correct = problem.IsAnswer1Correct,
                IsAnswer2Correct = problem.IsAnswer2Correct,
                IsAnswer3Correct = problem.IsAnswer3Correct,
                IsAnswer4Correct = problem.IsAnswer4Correct,
                Question= problem.Question

            };
            return problemDisplayModel;
        }
    }
}
