
using LiteratureProject.Core.ViewModelDataConstants;
using LiteratureProject.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiteratureProject.Core.Models
{
    public class LiteratureWorkViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.NameRequiredLiterature)]
        [StringLength(200, ErrorMessage = ValidationMessages.NameMaxLengthLiterature)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.AuthorRequired)]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = ValidationMessages.TeacherRequired)]
        public string TeacherId { get; set; } = string.Empty;

        /// <summary>
        /// Dropdown options for authors.
        /// </summary>
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();

        /// <summary>
        /// Parts of the analysis for this literature work.
        /// </summary>
        public List<AnalysisPart> Parts { get; set; } = new List<AnalysisPart>
        {
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
            new AnalysisPart(),
        };
    }
}
