using LiteratureProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.Bg;

namespace LiteratureProject.Infrastructure.Data.Models.BulgarianModels
{
    public class DeckOfBulgarianProblems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DeckNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(CreatedByMaxLength)]
        public string CreatedBy { get; set; } = string.Empty;

        [Required]
        [MaxLength(CreatedByMaxLength)]
        public string CreatedById { get; set; } = string.Empty;

        public BulgarianDeckTopic Topic { get; set; }

        public IEnumerable<BulgarianProblem> BulgarianProblems { get; set; } = new List<BulgarianProblem>();
    }
}
