using LiteratureProject.Infrastructure.Data.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiteratureProject.Infrastructure.DataConstants.StudentAnalysis;
namespace LiteratureProject.Infrastructure.Data.Models
{
    public class StudentAnalysis
    {
        [Key]
        public int Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        [ForeignKey(nameof(StudentId))]
        public ApplicationUser Student { get; set; } = null!;
        [Comment("tells if an essay or an textanalysis")]
        public StudentAnalysisType AnalysisType { get; set; }

        public bool IsGraded { get; set; }
        [Range(typeof(decimal),GradeMinLength,GradeMaxLength)]
        public decimal? TotalGrade { get; set; }

        public IEnumerable<StudentWorkComponent> StudentWorkComponents { get; set; } = new List<StudentWorkComponent>();

    }
}
