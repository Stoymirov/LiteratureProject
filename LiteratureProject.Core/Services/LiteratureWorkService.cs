using LiteratureProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteratureProject.Core.Models;
using LiteratureProject.Core.Contracts;


using Microsoft.EntityFrameworkCore;
namespace LiteratureProject.Core.Services
{
    public class LiteratureWorkService:IliteratureWorkService
    {
        private ApplicationDbContext context;
        public LiteratureWorkService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AuthorServiceModel>> GetAuthorsAsync()
        {
            return await context.Authors
                .Select(x=>new AuthorServiceModel()
            {
                Id = x.Id,
                Name = x.Name,
            }   
            ).ToListAsync();
        }
    }
}
