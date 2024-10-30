using LiteratureProject.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LiteratureProject.Infrastructure.DataConstants.ApplicationUserConstants;
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

        public IEnumerable<LiteratureWork> LiteratureWorks { get; set; } = new List<LiteratureWork>();
    }
}
