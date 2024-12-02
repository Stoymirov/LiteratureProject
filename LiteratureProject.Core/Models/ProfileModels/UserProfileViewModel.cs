
using LiteratureProject.Core.ViewModelDataConstants;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace LiteratureProject.Core.Models.ProfileModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; } = string.Empty;

        [Required(ErrorMessage = ValidationMessages.FullNameRequired)]
        [StringLength(100, ErrorMessage = ValidationMessages.FullNameMaxLength)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = ValidationMessages.BioMaxLength)]
        public string Bio { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = ValidationMessages.LocationMaxLength)]
        public string Location { get; set; } = string.Empty;

        public string? ProfilePictureUrl { get; set; }

        [Required(ErrorMessage = ValidationMessages.RoleRequired)]
        [StringLength(50, ErrorMessage = ValidationMessages.RoleMaxLength)]
        public string Role { get; set; } = string.Empty;

        //[ProfilePictureValidation]
        public IFormFile? ProfilePicture { get; set; }
    }
}
