using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;

namespace Library.Services.Book
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddBookAsync(AddBookViewModel viewModel)
        {
            Data.Entities.Book book = new Data.Entities.Book()
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                Author = viewModel.Author,
                ImageUrl = viewModel.Url,
                Rating = viewModel.Rating,
                CategoryId = viewModel.CategoryId
            };

            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddBookToCollection(string userId, BookViewModel model)
        {
            bool alreadyAdded = await _dbContext.IdentityUsersBooks
                .AnyAsync(u => u.CollectorId == userId && u.BookId == model.Id);
            
            if (alreadyAdded == false)
            {
                var userBook = new IdentityUserBook()
                {
                    BookId = model.Id,
                    CollectorId = userId
                };

                await _dbContext.IdentityUsersBooks.AddAsync(userBook);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> AddCategoriesToBook()
        {
            var categories = await _dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            var book = new AddBookViewModel()
            {
                Categories = categories
            };

            return book;
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int id)
        {
            var book = await _dbContext.Books
                .FirstOrDefaultAsync(b => b.Id == id);

            if (book == null)
            {
                return null;
            }

            var model = new BookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Rating = book.Rating,
                ImageUrl = book.ImageUrl
            };

            return model;
        }

        public async Task RemoveBookFromCollection(string userId, BookViewModel model)
        {
            var book = await _dbContext.IdentityUsersBooks
                .FirstOrDefaultAsync(u => u.CollectorId == userId && u.BookId == model.Id);

            if (book != null)
            {
                _dbContext.IdentityUsersBooks.Remove(book);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<ICollection<AllBookViewModel>> ShowAllBooksAsync()
        {
            return await _dbContext.Books
                .Select(b => new AllBookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task<ICollection<MyBooksViewModel>> ShowMineBooksAsync(string id)
        {
            return await _dbContext.IdentityUsersBooks  
                .Where(u => u.CollectorId == id)
                .Select(u => new MyBooksViewModel
                {
                    Id = u.BookId,
                    Title = u.Book.Title,
                    Author = u.Book.Author,
                    Description = u.Book.Description,
                    ImageUrl = u.Book.ImageUrl,
                    Category = u.Book.Category.Name
                }).ToListAsync();
        }
    }
}
