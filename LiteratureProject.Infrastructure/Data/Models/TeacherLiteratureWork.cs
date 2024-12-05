using LiteratureProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.ApplicationUser;

namespace LiteratureProject.Infrastructure.Data.Models
{
    [PrimaryKey(nameof(ApplicationUserId), nameof(LiteratureWorkId))]
    public class TeacherLiteratureWork
    {
        [MaxLength(IdMaxLength)]
        public string ApplicationUserId { get; set; } = string.Empty;

        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser Teacher { get; set; } = null!;

        public int LiteratureWorkId { get; set; }

        [ForeignKey(nameof(LiteratureWorkId))]
        public LiteratureWork LiteratureWork { get; set; } = null!;
    }
}
