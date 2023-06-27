using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants.Event;

namespace Homies.Models

{
    public class EditEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NAME_MAX_LENGTH, MinimumLength = NAME_MIN_LENGTH)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DESCRIPTION_MAX_LENGTH, MinimumLength = DESCRIPTION_MIN_LENGTH)]
        public string Description { get; set; } = null!;

        [Required]
        public string Start { get; set; } = null!;

        [Required]
        public string End { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public ICollection<TypeEventViewModel> Types { get; set; }
            = new HashSet<TypeEventViewModel>();
    }
}
