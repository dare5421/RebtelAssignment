using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data
{
    public class LibraryDbContext:DbContext
    {

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options):base(options)   
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }

    }
}
