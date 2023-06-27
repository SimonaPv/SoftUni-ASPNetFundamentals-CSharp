using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.Category;

namespace Library.Data.Entities
{
    [Comment("Categories of the books")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
            = new HashSet<Book>();
    }
}
