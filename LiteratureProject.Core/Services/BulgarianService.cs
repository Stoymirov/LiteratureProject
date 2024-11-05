using LiteratureProject.Core.Contracts;
using LiteratureProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Services
{
    public class BulgarianService:IBulgarianService
    {
        private ApplicationDbContext context;
        public BulgarianService(ApplicationDbContext context)
        {
            this.context = context;
        }
    }
}
