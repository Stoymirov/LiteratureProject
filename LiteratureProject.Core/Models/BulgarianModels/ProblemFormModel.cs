using LiteratureProject.Core.ViewModelDataConstants;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiteratureProject.Core.Models.BulgarianModels
{
    public class ProblemFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.QuestionRequired)]
        [StringLength(500, ErrorMessage = ValidationMessages.QuestionMaxLength)]
        public string Question { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.AnswerRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.AnswerMaxLength)]
        public string Answer1 { get; set; } = string.Empty;

        public bool IsAnswer1Correct { get; set; }

        [Required(ErrorMessage = ValidationMessages.AnswerRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.AnswerMaxLength)]
        public string Answer2 { get; set; } = string.Empty;

        public bool IsAnswer2Correct { get; set; }

        [Required(ErrorMessage = ValidationMessages.AnswerRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.AnswerMaxLength)]
        public string Answer3 { get; set; } = string.Empty;

        public bool IsAnswer3Correct { get; set; }

        [Required(ErrorMessage = ValidationMessages.AnswerRequired)]
        [StringLength(200, ErrorMessage = ValidationMessages.AnswerMaxLength)]
        public string Answer4 { get; set; } = string.Empty;

        public bool IsAnswer4Correct { get; set; }

        [Required(ErrorMessage = ValidationMessages.ExplanationRequired)]
        [StringLength(1000, ErrorMessage = ValidationMessages.ExplanationMaxLength)]
        public string Explanation { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.DeckSelectionRequired)]
        public int DeckOfProblemsId { get; set; }

        public List<SelectListItem> DeckOptions { get; set; } = new List<SelectListItem>();
    }
}
