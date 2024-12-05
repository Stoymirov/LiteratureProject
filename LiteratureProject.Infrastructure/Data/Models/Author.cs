using System.ComponentModel.DataAnnotations;
using static LiteratureProject.Infrastructure.DataConstants.ValidationConstants.Author;

namespace LiteratureProject.Infrastructure.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;
    }
}
