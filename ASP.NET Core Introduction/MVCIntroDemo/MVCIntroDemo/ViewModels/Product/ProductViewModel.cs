using System.ComponentModel.DataAnnotations;

namespace MVCIntroDemo.ViewModels.Product
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
