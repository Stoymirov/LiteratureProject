using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Core.Models.TestingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Contracts
{
    public interface ITestingService
    {
        public Task<IEnumerable<DeckDisplayModel>> GetAllDecksAsync();
        public Task<DeckDisplayModel> GetDeckByIdAsync(int id);
        public Task<ProblemTestingModel> GetNextQuestionAsync(int deckId, int problemNumber = 1, int problemId = 0);
        public Task<int> GetCountOfProblemsByDeckId(int deckId);
    }
}
