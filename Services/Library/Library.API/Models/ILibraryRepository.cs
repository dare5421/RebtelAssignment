using System.Runtime.Serialization;

namespace Library.API.Models
{
    public interface ILibraryRepository
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<List<Book>> GetMostBorrowedBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task<List<BookBorrow>> GetBookBorrowByBookIdAsync(int bookId);
        Task<List<BookBorrow>> GetBookBorrowsInTimeFrameAsync(DateTime startFrame, DateTime endFrame);
        Task<List<BookBorrow>> GetBorrowedBookByUser(int borrowerId);
        Task<List<BookBorrow>> GetOtherBooks(int bookId);

    }
}
