using Library.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.API.Data.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly LibraryDbContext _db;
        public LibraryRepository(LibraryDbContext db)
        {
            _db = db;   
        }
        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<List<BookBorrow>> GetBookBorrowByBookIdAsync(int bookId)
        {
            return await _db.BookBorrows.Where(_ => _.BookId == bookId).ToListAsync();
        }

        public async Task<List<BookBorrow>> GetBookBorrowsInTimeFrameAsync(DateTime startFrame, DateTime endFrame)
        {
            return await _db.BookBorrows.Where(_ => (_.BorrowDate >= startFrame && _.BorrowDate <= endFrame)).ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await _db.Books.Where(_ => _.Id == bookId).FirstOrDefaultAsync();
        }

        public async Task<List<BookBorrow>> GetBorrowedBookByUser(int borrowerId)
        {
            return await _db.BookBorrows.Where(_ => _.BorrowerId == borrowerId).ToListAsync();
        }

        public async Task<List<Book>> GetMostBorrowedBooksAsync()
        {
            var lst = _db.BookBorrows
                 .GroupBy(x => x.BookId, (g, l) =>
                     new { BookId = g, BookCount = l.Count() })
                 .OrderByDescending(x => x.BookCount);

            var books = _db.Books;
  

            var mostBorrowedBooks = await lst.Join(books,
                        x => x.BookId,
                        y => y.Id,
                        (x, y) => y).Take(3).ToListAsync();

            return mostBorrowedBooks;
        }

        public async Task<List<BookBorrow>> GetOtherBooks(int bookId)
        {
            return await _db.BookBorrows.Where(x => x.BookId == bookId)
                .Join(_db.BookBorrows,
                    x => x.BorrowerId,
                    y => y.BorrowerId,
                    (x, y) => y
                )
                .Where(x=>x.BookId!=bookId).ToListAsync();
        }
    }
}
