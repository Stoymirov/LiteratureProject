using LiteratureProject.Core.Models.BulgarianModels;
using LiteratureProject.Infrastructure.Data.Enums;
using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Contracts
{
    public interface IBulgarianService
    {
        public Task<int> AddDeckAsync(DeckFormModel model,string userid);
        public Task<int> AddProblemAsync(ProblemFormModel model);
        public Task<IEnumerable<DeckOfBulgarianProblems>> GetAllDecksByUserId(string userId);

        public Task<DeckOfBulgarianProblems> GetDeckByDeckIdAsync(int deckId);
        public Task<IEnumerable<ProblemDisplayModel>> GetProblemsByDeckIdAsync(int deckId);
        public Task<ProblemFormModel> GetProblemByIdAsync(int problemId);
        public Task<int> EditProblemAsync(ProblemFormModel model);
    }
}
