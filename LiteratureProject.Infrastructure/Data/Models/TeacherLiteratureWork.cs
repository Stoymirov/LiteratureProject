using LiteratureProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteratureProject.Infrastructure.Data.Models
{
    [PrimaryKey(nameof(ApplicationUserId),nameof(LiteratureWorkId))]
    public class TeacherLiteratureWork
    {
        public string ApplicationUserId { get; set; } = string.Empty;
        [ForeignKey(nameof(ApplicationUserId))]
        public ApplicationUser Teacher { get; set; } = null!;
        public int LiteratureWorkId { get; set; }
        [ForeignKey(nameof(LiteratureWorkId))]
        public LiteratureWork LiteratureWork { get; set; } = null!;
    }
}
