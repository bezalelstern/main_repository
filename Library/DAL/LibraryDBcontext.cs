using Microsoft.EntityFrameworkCore;
using Library.Models;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Library.DAL
{
    public class LibraryDBcontext : DbContext
    {
        public DbSet<Genre> genres { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Shelf> shelf { get; set; }

        public DbSet<Bookset> set { get; set; }

        public LibraryDBcontext(DbContextOptions<LibraryDBcontext> options)
        : base(options)
        {
            //Database.EnsureCreated();
            if (Database.EnsureCreated() && genres.Count() == 0)
            {
                Seed();
            }
        }


        private void Seed()
        {
            Genre friend = new Genre()
            {
                Name = "history"
            };

            genres.Add(friend);
            SaveChanges();
        }
    }
}
