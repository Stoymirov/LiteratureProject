using LiteratureProject.Core.Models.BulgarianModels;
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
    }
}
