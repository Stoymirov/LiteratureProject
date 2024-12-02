
using LiteratureProject.Core.ViewModelDataConstants;
using LiteratureProject.Infrastructure.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace LiteratureProject.Core.Models.BulgarianModels
{
    public class DeckFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ValidationMessages.NameRequired)]
        [StringLength(100, ErrorMessage = ValidationMessages.NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.CreatedByRequired)]
        public string CreatedBy { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.CreatedByIdRequired)]
        public string CreatedById { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.TopicRequired)]
        public BulgarianDeckTopic SelectedTopic { get; set; }
    }
}
