using LiteratureProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Contracts
{
    public interface IliteratureWorkService
    {
        public Task<IEnumerable<AuthorServiceModel>> GetAuthorsAsync();
    }
}
