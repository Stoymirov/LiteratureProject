using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.LiteratureWork;

namespace LiteratureProject.Data.Models
{
    public class LiteratureWork
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        public bool IsDeleted { get; set; }

        [Comment("The purpose of this is to hold and differentiate all different parts of the analysis and make sure that no one long string as description is held in the database")]
        public IList<AnalysisPart> AnalysisParts { get; set; } = new List<AnalysisPart>();

        public IList<TeacherLiteratureWork> TeacherLiteratureWorks { get; set; } = new List<TeacherLiteratureWork>();
    }
}
