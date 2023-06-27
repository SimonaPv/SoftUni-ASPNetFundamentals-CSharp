using Library.Models;

namespace Library.Services.Book
{
    public interface IBookService
    {
        Task<ICollection<AllBookViewModel>> ShowAllBooksAsync();
        Task<ICollection<MyBooksViewModel>> ShowMineBooksAsync(string id);
        Task<AddBookViewModel> AddCategoriesToBook();
        Task AddBookAsync(AddBookViewModel viewModel);
        Task<BookViewModel?> GetBookByIdAsync(int id);
        Task AddBookToCollection(string userId, BookViewModel model);
        Task RemoveBookFromCollection(string userId, BookViewModel model);
    }
}
