using LiteratureProject.Infrastructure.Data.Models.BulgarianModels;
using System;
using LiteratureProject.Core.ViewModelDataConstants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.TestingModels
{
    [AtLeastOneCorrectAnswer]
    public class ProblemTestingModel
    {
        
        public int Id { get; set; }
        
        public string Question { get; set; } = string.Empty;

        
        public string Answer1 { get; set; } = string.Empty;
        public bool IsAnswer1Correct { get; set; }

        
        public string Answer2 { get; set; } = string.Empty;
        public bool IsAnswer2Correct { get; set; }

        
        public string Answer3 { get; set; } = string.Empty;
        public bool IsAnswer3Correct { get; set; }

       
        public string Answer4 { get; set; } = string.Empty;
        public bool IsAnswer4Correct { get; set; }


        public string Explanation { get; set; } = string.Empty;
        public int DeckOfProblemsId { get; set; }
        
    }
}
