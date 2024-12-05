using LiteratureProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.StudentWorkComponent;

namespace LiteratureProject.Infrastructure.Data.Models
{
    public class StudentWorkComponent
    {
        [Key]
        public int Id { get; set; }

        public StudentWorkComponentType? ComponentType { get; set; }

        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;

        [Required]
        public int StudentAnalysisId { get; set; }

        [ForeignKey(nameof(StudentAnalysisId))]
        public StudentAnalysis StudentAnalysis { get; set; }
    }
}
