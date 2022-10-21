using ApiGateway.Models;
using Borrower.API.gRPC.Protos;
using Google.Protobuf.Collections;
using Grpc.Net.Client;
using Library.API.gRPC;
using Library.API.gRPC.Protos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
    public class ApiController : ControllerBase
    {
        /// <summary>
        /// Get the most top 3 borrowed books
        /// </summary>
        [HttpGet]
        [Route("most-borrowed")]
        public async Task<IActionResult> GetMostBorrowedBooks()
        {
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            var libraryResponse = await libraryClient.GetMostBorrowedBooksAsync(new Empty());

            return Ok(libraryResponse);
        }

        /// <summary>
        /// Get the number of available and borrowed copies of a specific book
        /// </summary>
        [HttpGet]
        [Route("available-copies")]
        public async Task<IActionResult> GetAvailableCopies(int bookId)
        {
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            var libraryResponse = await libraryClient.GetAvailableCopiesByIdAsync(new GetAvailableCopiesByIdRequest { BookId = bookId});

            return Ok(libraryResponse);
        }

        /// <summary>
        /// Get the the read rate (pages per day) for a particular book
        /// </summary>
        [HttpGet]
        [Route("read-rate")]
        public async Task<IActionResult> GetBookReadRate(int bookId)
        {
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            var libraryResponse = await libraryClient.GetBookReadRateAsync(new GetBookReadRateRequest { BookId = bookId });

            return Ok(libraryResponse);
        }

        /// <summary>
        /// Get the most top 3 active borrowers in a specific time frame
        /// </summary>
        [HttpGet]
        [Route("active-borrowers")]
        public async Task<IActionResult> GetMostActiveBorrowers(DateTime startFrame, DateTime endTime)
        {
            var borrowerChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var borrowerClient = new BorrowerService.BorrowerServiceClient(borrowerChannel);
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            
            var bookBorrowResponse = await libraryClient.GetBookBorrowsInTimeFrameAsync(new GetBookBorrowsInTimeFrameRequest { StartFrame = startFrame.ToString(), EndFrame = endTime.ToString() });
            var borrowersIds =  bookBorrowResponse.BookBorrow
                .GroupBy(_ => _.BorrowerId, (g, l) => new { BorrowerId = g, BorrowedBooksCount = l.Count() })
                .OrderByDescending(_ => _.BorrowedBooksCount)
                .Take(3)
                .Select(x=> new
                {
                    BorrowerId = x.BorrowerId,
                    BorrowedBooksCount = x.BorrowedBooksCount
                }).ToList();

            var ids = new GetBorrowersByIdsRequest();
            ids.BorrowerIds.AddRange(borrowersIds.Select(x=>x.BorrowerId).ToArray());
            var borrowers = await borrowerClient.GetBorrowersByIdsAsync(ids);
            var borrowersActivity = borrowers.Borrowers.Join(borrowersIds,
                x => x.Id,
                y => y.BorrowerId,
                (x, y) => new BorrowersActivity
                {
                    Name = x.Name,
                    BorrowedCount = y.BorrowedBooksCount
                });
          

            return Ok(borrowersActivity);

        }

        /// <summary>
        /// Get the borrowed books of an individual in each time frame
        /// </summary>
        [HttpGet]
        [Route("user-borrowed-books")]
        public async Task<IActionResult> GetBorrowedBookByUser(int borrowerId)
        {
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            var libraryResponse = await libraryClient.GetBorrowedBookByUserAsync(new GetBorrowedBookByUserRequest { BorrowerId = borrowerId});

            var borrowedBooks = libraryResponse.BorrowedBooks
                .Select(x => new
                {
                    x.Book.Name,
                    x.BorrowDate,
                    x.RetriveDate
                });

            return Ok(borrowedBooks);

        }

        /// <summary>
        /// Get other books which has been borrowed by others who read a particular book
        /// </summary>
        [HttpGet]
        [Route("other-books")]
        public async Task<IActionResult> GetOtherBooks(int bookId)
        {
            var libraryChannel = GrpcChannel.ForAddress("https://localhost:5003");
            var libraryClient = new LibraryService.LibraryServiceClient(libraryChannel);
            var libraryResponse = await libraryClient.GetOtherBooksAsync(new GetOtherBooksRequest { BookId = bookId });

            var otherBooks = libraryResponse.Books
                .Select(x => new
                {
                    x.BookId,
                    x.Book.Name
                });

            return Ok(otherBooks);
        }
    }
}