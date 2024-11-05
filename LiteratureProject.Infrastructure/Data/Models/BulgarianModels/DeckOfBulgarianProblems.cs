using LiteratureProject.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.Data.Models.BulgarianModels
{
    public class DeckOfBulgarianProblems
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public BulgarianDeckTopic Topic { get; set; }
        public IEnumerable<BulgarianProblem> BulgarianProblems { get; set; } = new List<BulgarianProblem>();
    }
}
