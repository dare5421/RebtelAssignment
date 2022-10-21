using Grpc.Core;
using Library.API.gRPC.Protos;
using Library.API.Models;

namespace Library.API.gRPC
{
    public class LibraryGrpcService:LibraryService.LibraryServiceBase
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryGrpcService(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public override async Task<GetMostBorrowedBooksResponse> GetMostBorrowedBooks(Empty request, ServerCallContext context)
        {
            var booksData = await _libraryRepository.GetMostBorrowedBooksAsync();
            GetMostBorrowedBooksResponse response = new();
                        
            foreach (var book in booksData)
            {
                response.Books.Add(new GetMostBorrowedBooksResponseItem
                { 
                    Author = book.Author,
                    BorrowedCopies = book.BorrowedCopies,
                    Description = book.Description,
                    Edition = book.Edition,
                    Id = book.Id,
                    Name = book.Name,
                    Pages = book.Pages,
                    PublishedYear = book.PublishedYear,
                    Publisher = book.Publisher,
                    TotalCopies = book.TotalCopies
                });
            }
            return response;
        }
        
        public override async Task<GetAvailableCopiesByIdResponse> GetAvailableCopiesById(GetAvailableCopiesByIdRequest request, ServerCallContext context)
        {
            var data = await _libraryRepository.GetBookByIdAsync(request.BookId);
            var response = new GetAvailableCopiesByIdResponse
            {
                NumberOfAvailableCopies = data.TotalCopies - data.BorrowedCopies,
                NumberOfBorrowedCopies = data.BorrowedCopies            
            };
            return response;
        }

        // pages/(ds-de)
        public override async Task<GetBookReadRateResponse> GetBookReadRate(GetBookReadRateRequest request, ServerCallContext context)
        {
            var bookBorrows = await _libraryRepository.GetBookBorrowByBookIdAsync(request.BookId);
           
            var response = new GetBookReadRateResponse
            {
                ReadRate = bookBorrows.Average(x =>
                 (x.Book.Pages / (x.RetriveDate - x.BorrowDate).TotalDays)
                )
            };
            
            return response ;
        }

        public override async Task<GetBookBorrowsInTimeFrameResponse> GetBookBorrowsInTimeFrame(GetBookBorrowsInTimeFrameRequest request, ServerCallContext context)
        {
            var bookBorrows = await _libraryRepository.GetBookBorrowsInTimeFrameAsync(DateTime.Parse( request.StartFrame), DateTime.Parse(request.EndFrame));
            var response = new GetBookBorrowsInTimeFrameResponse();

            foreach(var bookBorrow in bookBorrows)
            {
                response.BookBorrow.Add(new GetBookBorrowsInTimeFrameItem
                {
                    BookId = bookBorrow.BookId,
                    BorrowDate = bookBorrow.BorrowDate.ToString(),
                    BorrowerId = bookBorrow.BorrowerId,
                    RetriveDate = bookBorrow.RetriveDate.ToString()
                });
            }
            return response;
        }
        public override async Task<GetBorrowedBookByUserResponse> GetBorrowedBookByUser(GetBorrowedBookByUserRequest request, ServerCallContext context)
        {
            var borrowedBooks = await _libraryRepository.GetBorrowedBookByUser(request.BorrowerId);
            var response = new GetBorrowedBookByUserResponse();
            foreach (var borrow in borrowedBooks)
            {
                response.BorrowedBooks.Add(new GetBorrowedBookByUserItem
                {
                    BookId = borrow.BookId,
                    BorrowDate = borrow.BorrowDate.ToString(),
                    BorrowerId = borrow.BorrowerId,
                    RetriveDate = borrow.RetriveDate.ToString(),
                    Book = new GetBorrowedBookByUserBook
                    {
                        Id = borrow.BookId,
                        Name = borrow.Book.Name                        
                    }
                });
            }
            return response;
        }

        public override async Task<GetOtherBooksResponse> GetOtherBooks(GetOtherBooksRequest request, ServerCallContext context)
        {
            var booksData = await _libraryRepository.GetOtherBooks(request.BookId);
            var response = new GetOtherBooksResponse();
            foreach (var book in booksData)
            {
                response.Books.Add(new GetOtherBooksItem
                {
                    BookId = book.BookId,
                    BorrowerId = book.BorrowerId,
                    Book = new GetOtherBooksBook
                    {
                        Name = book.Book.Name
                    }
                });
            }
            
            return response;
        }
    }
}
