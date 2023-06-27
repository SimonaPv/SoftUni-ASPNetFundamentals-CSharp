using Library.Models;
using Library.Services.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Library.Controllers
{
    public class BookController : BaseController
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var model = await _bookService.ShowAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await _bookService.ShowMineBooksAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All", "Book");
            }

            string userId = GetUserId();
            await _bookService.AddBookToCollection(userId, book);

            return RedirectToAction("All", "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("Mine", "Book");
            }

            string userId = GetUserId();
            await _bookService.RemoveBookFromCollection(userId, book);

            return RedirectToAction("Mine", "Book");
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = await _bookService.AddCategoriesToBook();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _bookService.AddBookAsync(model);
            return RedirectToAction("All", "Book");
        }
    }
}
