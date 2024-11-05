using LiteratureProject.Core.Models.BulgarianModels;
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
        public Task<int> AddDeckAsync(DeckFormModel model);
      
    }
}
