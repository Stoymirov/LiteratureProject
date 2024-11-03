using LiteratureProject.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.LiteratureWorkModels
{
    public class LiteratureWorkDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public string TeacherName { get; set; }
        public List<AnalysisPart> AnalysisParts { get; set; } = new List<AnalysisPart>();
        public int CurrentPart { get; set; } 
    }
}
