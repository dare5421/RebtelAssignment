using Library.API.Models;

namespace Library.API.Data
{
    public static class LibraryDbContextSeed
    {
        public static async Task SeedAsync(this LibraryDbContext db)
        {
            db.Database.EnsureCreated();
            if (!db.Books.Any())
            {
                await SeedBooks(db);
            }
        }

        public static async Task SeedBooks(LibraryDbContext db)
        {
            await db.Books.AddRangeAsync(
                new Book
                {
                    Name = "Things Fall Apart",
                    Author = "Chinua Achebe",
                    PublishedYear = 1958,
                    Pages = 209,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 10,
                    BorrowedCopies = 5,
                    Description = "1"
                },
                new Book
                {
                    Name = "Fairy tales",
                    Author = "Hans Christian Andersen",
                    PublishedYear = 1958,
                    Pages = 784,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 20,
                    BorrowedCopies = 5,
                    Description = "2"
                },
                new Book
                {
                    Name = "The Divine Comedy",
                    Author = "Dante Alighieri",
                    PublishedYear = 1958,
                    Pages = 928,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 5,
                    BorrowedCopies = 0,
                    Description = "3"
                },
                new Book
                {
                    Name = "Wuthering Heights",
                    Author = "Emily Brontë",
                    PublishedYear = 1958,
                    Pages = 342,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 12,
                    BorrowedCopies = 7,
                    Description = "4"
                },
                new Book
                {
                    Name = "Journey to the End of the Night",
                    Author = "Louis-Ferdinand Céline",
                    PublishedYear = 1958,
                    Pages = 505,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 15,
                    BorrowedCopies = 10,
                    Description = "5"
                },
                new Book
                {
                    Name = "Great Expectations",
                    Author = "Charles Dickens",
                    PublishedYear = 1958,
                    Pages = 194,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 5,
                    BorrowedCopies = 3,
                    Description = "6"
                },
                new Book
                {
                    Name = "Sentimental Education",
                    Author = "Gustave Flaubert",
                    PublishedYear = 1958,
                    Pages = 606,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 25,
                    BorrowedCopies = 10,
                    Description = "7"
                },
                new Book
                {
                    Name = "The Tin Drum",
                    Author = "Günter Grass",
                    PublishedYear = 1958,
                    Pages = 600,
                    Edition = 2,
                    Publisher = "p1",
                    TotalCopies = 5,
                    BorrowedCopies = 0,
                    Description = "8"
                }
            );
            await db.SaveChangesAsync();


            await db.BookBorrows.AddRangeAsync(
                new BookBorrow
                {
                    BookId = 1,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 11)
                },
                new BookBorrow
                {
                    BookId = 1,
                    BorrowerId = 2,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 05)
                },
                new BookBorrow
                {
                    BookId = 1,
                    BorrowerId = 3,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 08)
                },
                new BookBorrow
                {
                    BookId = 1,
                    BorrowerId = 4,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 23)
                },
                new BookBorrow
                {
                    BookId = 1,
                    BorrowerId = 5,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 12)
                },
                new BookBorrow
                {
                    BookId = 2,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 15)
                },
                new BookBorrow
                {
                    BookId = 3,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 03)
                },
                new BookBorrow
                {
                    BookId = 3,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 09)
                },
                new BookBorrow
                {
                    BookId = 4,
                    BorrowerId = 2,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 12)
                },
                new BookBorrow
                {
                    BookId = 5,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 11)
                },
                new BookBorrow
                {
                    BookId = 6,
                    BorrowerId = 3,
                    BorrowDate = new DateTime(2022, 01, 01),
                    RetriveDate = new DateTime(2022, 01, 13)
                },
                new BookBorrow
                {
                    BookId = 7,
                    BorrowerId = 1,
                    BorrowDate = new DateTime(2022, 01, 03),
                    RetriveDate = new DateTime(2022, 01, 11)
                }
            );
            await db.SaveChangesAsync();
        }
    }
}
