using LiteratureProject.Core.Models;
using LiteratureProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LiteratureProject.Core.Contracts
{
    public interface ILiteratureWorkService
    {
        public Task<IEnumerable<AuthorServiceModel>> GetAuthorsAsync();
        public Task<bool> AuthorExistsAsync(int authorId);
        public Task<int> CreateAsync(LiteratureWorkViewModel literatureWork,string teacherId);
        public Task<IEnumerable<LiteratureWork>> AllLiteratureWorksByTeacherId(string teacherId);
        
    }
}
