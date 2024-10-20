using LiteratureProject.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiteratureProject.Data.Models
{
    public class LiteratureWork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public Author Author { get; set; }

        public IEnumerable<ApplicationUser> CreatorsOfAnalysis { get; set; } = new List<ApplicationUser>();
        public IEnumerable<AnalysisPart> AnalysisParts { get; set; } = new List<AnalysisPart>();
    }
}
