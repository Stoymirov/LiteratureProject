using LiteratureProject.Data.Models;
using LiteratureProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LiteratureProject.Infrastructure.DataConstants.AnalysisPartConstants;
namespace LiteratureProject.Infrastructure.Data.Models
{
    public class AnalysisPart
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = string.Empty;
        public int LiteratureWorkId { get; set; }
        [ForeignKey(nameof(LiteratureWorkId))]
        public LiteratureWork LiteratureWork { get; set; } = null!;
        [Comment("This is to show what kind of analysis part we are looking at. If it shows the topics, themes, etc.")]
        public AnalysisPartType Type {get; set; }

    }
}
