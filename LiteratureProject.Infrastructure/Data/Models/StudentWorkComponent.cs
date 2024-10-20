using LiteratureProject.Infrastructure.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.Data.Models
{
    public class StudentWorkComponent
    {
        [Key]
        public int Id { get; set; }
        public StudentWorkComponentType? ComponentType { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public int StudentAnalysisId { get; set; }
        [ForeignKey(nameof(StudentAnalysisId))]
        public StudentAnalysis StudentAnalysis { get; set; }
    }
}
