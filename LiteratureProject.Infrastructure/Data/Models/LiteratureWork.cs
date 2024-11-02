using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteratureProject.Data.Models
{
    public class LiteratureWork
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

      
        [Comment("The purpose of this is to hold and differenciate all different parts of the analysis and make sure that no one long string as description is held in the database")]
        public IList<AnalysisPart> AnalysisParts { get; set; } = new List<AnalysisPart>();
    }
}
