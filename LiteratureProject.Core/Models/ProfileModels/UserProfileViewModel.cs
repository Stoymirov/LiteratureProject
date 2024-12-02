using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Core.Models.ProfileModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Location { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string Role { get; set; }

        public IFormFile? ProfilePicture { get; set; }
    }
}
