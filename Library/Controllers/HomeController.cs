using Library.DAL;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LibraryDBcontext _context;

        public HomeController(LibraryDBcontext LibraryContext, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = LibraryContext;
        }

        public IActionResult Index()
        {
            return View(_context.genres.ToList());
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {

            if (genre == null)
            {
                return RedirectToAction("Index");
            }
            _context.genres.Add(genre);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult AddShelf(int Id)
        {
            var genre = _context.genres
                .Include(g => g.Shelves)
                .FirstOrDefault(g => g.Id == Id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddShelf(int genreId, int height, int width)
        {
            var genre = _context.genres
                .Include(g => g.Shelves)
                .FirstOrDefault(g => g.Id == genreId);
            var shelf = new Shelf
            {
                Height = height,
                Width = width,
                GenreId = genreId
            };

            genre.Shelves.Add(shelf);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

   

        public IActionResult Details(int id)
        {
            var genre = _context.genres
                .Include(g => g.Shelves)
                .FirstOrDefault(g => g.Id == id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre.Shelves);
        }





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
