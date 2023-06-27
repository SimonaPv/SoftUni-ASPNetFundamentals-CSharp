using System.ComponentModel.DataAnnotations;
using static Library.Data.DataConstants.Book;

namespace Library.Models
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(TITLE_MAX_LENGTH, MinimumLength = TITLE_MIN_LENGTH)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(AUTHOR_MAX_LENGTH, MinimumLength = AUTHOR_MIN_LENGTH)]
        public string Author { get; set; } = null!;

        [Required]
        public string Url { get; set; } = null!;

        [Required]
        public decimal Rating { get; set; }

        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public ICollection<CategoryViewModel> Categories { get; set; }
            = new HashSet<CategoryViewModel>();
    }
}
