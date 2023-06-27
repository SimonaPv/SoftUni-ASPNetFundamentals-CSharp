using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Data.DataConstants.Book;

namespace Library.Data.Entities
{
    [Comment("Books for the library")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AUTHOR_MAX_LENGTH)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range((double)RATING_MIN_LENGTH, (double)RATING_MAX_LENGTH)]
        public decimal Rating { get; set; }

        [Required]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; }
            = new HashSet<IdentityUserBook>();
    }
}
