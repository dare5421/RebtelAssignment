using Microsoft.EntityFrameworkCore;

namespace Borrower.API.Data
{
    public class BorrowerDbContext : DbContext
    {
        public BorrowerDbContext(DbContextOptions<BorrowerDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Models.Borrower> Borrowers { get; set; }
    }
}
