using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.TestingModels
{
    public class QuestionResultViewModel
    {
        public bool IsCorrect { get; set; }
        public string Explanation { get; set; }
        public int DeckId { get; set; }
        public int NextProblemNumber { get; set; }
        public int ProblemId { get; set; }
    }
}
