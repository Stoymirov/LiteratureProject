using LiteratureProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.AdminModels
{
    public class AdminDashboardViewModel
    {
        public int UserCount { get; set; }
        public int DeckCount { get; set; }
        public int LiteratureWorksCount { get; set; }
        public int AuthorsCount { get; set; }
        
       
    }

}
