using Borrower.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Borrower.API.Data.Repository
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly BorrowerDbContext _db;

        public BorrowerRepository(BorrowerDbContext db)
        {
            _db = db;
        }

        public async Task<List<Models.Borrower>> GetAllBorrowersAsync()
        {
            return await _db.Borrowers.ToListAsync();
        }

        public async Task<List<Models.Borrower>> GetBorrowersByIds(int[] ids) { 
            return await _db.Borrowers.Where(_=> ids.Contains(_.Id)).ToListAsync();
        }
    }
}
