namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public decimal Rating { get; set; }
    }
}
