#nullable disable
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIntroduction.Models
{
    public class AddCarViewModel
    {
        [Required]
        [StringLength(50)]
        public string Make { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Range(1886, 2023)]
        public int Year { get; set; }

        [Range(0.0, 1_000_000_000.0)]
        public decimal Price { get; set; }
    }
}
