using Library.DAL;
using Library.Models;
using Library.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly LibraryDBcontext _context;
        private Book _book;

        public BookController(LibraryDBcontext LibraryContext, ILogger<BookController> logger)
        {
            _logger = logger;
            _context = LibraryContext;
        }
        public IActionResult Booklist()
        {
            return View(_context.books.ToList());
        }
        public IActionResult Create()
        {
            BookWithSet BS = new BookWithSet()
            {
                Book = new Book(),
                Booksets = _context.set.ToList(),
                Genres = _context.genres.ToList(),
                Shelf = _context.shelf.ToList(),    
            };
            return View(BS);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (book == null)
            {
                return RedirectToAction("Index");
            }
            var genre = _context.genres
                .Include(g => g.Books)
                .ToList().Find(f => f.Id == book.Genre);

            genre.Books.Add(book);
            _context.books.Add(book);
            _context.SaveChanges();
            Book book1 = _context.books.ToList().Find(f => f.Name == book.Name);
            int id = book.Id;

            return RedirectToAction("Selectashelf", new { id = id });
        }

        public IActionResult Selectashelf(int id)
        {

            var book = _context.books.ToList().Find(f => f.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var genre = _context.genres
                .Include(g => g.Shelves)
                .ToList()
                .Find(f => f.Id == book.Genre);

            var shelfWithBooksList = new List<ShelfWithBook>();
            foreach (var shelf in genre.Shelves)
            {
                shelfWithBooksList.Add(new ShelfWithBook
                {
                    Book = book,
                    Shelves = new List<Shelf> { shelf }
                });
            }

            return View(shelfWithBooksList);
        
        }


        public IActionResult Add(int bookId, int shelfId)
        {
          
                var book = _context.books
                    .Find(bookId);

                var shelf = _context.shelf
                    .Include(s => s.Book)
                    .FirstOrDefault(s => s.Id == shelfId);
                if (book.height < shelf.Height && book.width < shelf.Width)
                {
                    shelf.Book.Add(book);
                    shelf.Width -= book.width;
                    _context.SaveChanges();
                    return RedirectToAction("Booklist");
                }
                else
                {
                    ModelState.AddModelError("", "הספר אינו מתאים למידות המדף");
                    return RedirectToAction("select", new { id = bookId });
                }


        }


        public IActionResult select(int id)
        {

            var book = _context.books.ToList().Find(f => f.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var genre = _context.genres
                .Include(g => g.Shelves)
                .ToList()
                .Find(f => f.Id == book.Genre);

            var shelfWithBooksList = new List<ShelfWithBook>();
            foreach (var shelf in genre.Shelves)
            {
                shelfWithBooksList.Add(new ShelfWithBook
                {
                    Book = book,
                    Shelves = new List<Shelf> { shelf }
                });
            }

            return View(shelfWithBooksList);
        }
    }
}
