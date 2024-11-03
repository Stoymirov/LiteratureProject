using LiteratureProject.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.LiteratureWorkModels
{
    public class AnalysisPartViewModel
    {
        public int Id { get; set; }
        public AnalysisPartType Type { get; set; }
        public string Content { get; set; }
    }
}
