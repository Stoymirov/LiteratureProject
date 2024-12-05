using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.Bg;

namespace LiteratureProject.Infrastructure.Data.Models.BulgarianModels
{
    public class BulgarianProblem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(QuestionMaxLength)]
        public string Question { get; set; } = string.Empty;

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer1 { get; set; } = string.Empty;
        public bool IsAnswer1Correct { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer2 { get; set; } = string.Empty;
        public bool IsAnswer2Correct { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer3 { get; set; } = string.Empty;
        public bool IsAnswer3Correct { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer4 { get; set; } = string.Empty;
        public bool IsAnswer4Correct { get; set; }

        [MaxLength(ExplanationMaxLength)]
        public string Explanation { get; set; } = string.Empty;

        public int DeckOfProblemsId { get; set; }

        [ForeignKey(nameof(DeckOfProblemsId))]
        public DeckOfBulgarianProblems Deck { get; set; }
    }
}
