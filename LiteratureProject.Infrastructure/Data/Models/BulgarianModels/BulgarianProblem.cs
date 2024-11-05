using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.Data.Models.BulgarianModels
{
    public class BulgarianProblem
    {
        public int Id { get; set; }
        [Required]
        public string Question { get; set; } = string.Empty;

        [Required]
        public string Answer1 { get; set; } = string.Empty;
        public bool IsAnswer1Correct { get; set; }

        [Required]
        public string Answer2 { get; set; } = string.Empty;
        public bool IsAnswer2Correct { get; set; }

        [Required]
        public string Answer3 { get; set; } = string.Empty;
        public bool IsAnswer3Correct { get; set; }

        [Required]
        public string Answer4 { get; set; } = string.Empty;
        public bool IsAnswer4Correct { get; set; }

       
        public string Explanation { get; set; } = string.Empty;
        public int DeckOfProblemsId { get; set; }
        [ForeignKey(nameof(DeckOfProblemsId))]
        public DeckOfBulgarianProblems Deck { get; set; }
    }
}
