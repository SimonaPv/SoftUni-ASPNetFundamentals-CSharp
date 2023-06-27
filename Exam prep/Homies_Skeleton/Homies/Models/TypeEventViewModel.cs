using System.ComponentModel.DataAnnotations;
using static Homies.Data.DataConstants.Type;

namespace Homies.Models
{
    public class TypeEventViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NAME_MAX_LENGTH, MinimumLength = NAME_MIN_LENGTH)]
        public string Name { get; set; } = null!;
    }
}
