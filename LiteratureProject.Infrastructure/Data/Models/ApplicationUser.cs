using LiteratureProject.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.ApplicationUserConstants;

namespace LiteratureProject.Infrastructure.Data.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MaxLength(FirstNameMaxLength)]
        [PersonalData]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(LastNameMaxLength)]
        [PersonalData]
        public string LastName { get; set; } = string.Empty;
        [MaxLength(LocationMaxLength)]
        [PersonalData]
        public string Location { get; set; } = string.Empty;
        [MaxLength(BioMaxLength)]
        [PersonalData]
        public string Bio { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;    
        public IEnumerable<TeacherLiteratureWork> TeacherLiteratureWorks { get; set; } = new List<TeacherLiteratureWork>();
    }
}
