namespace Library.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Publisher { get; set; }
        public string Author { get; set; }
        public int Edition { get; set; }
        public int PublishedYear { get; set; }
        public string Description { get; set; }
        public int Pages { get; set; }
        public int TotalCopies { get; set; }
        public int BorrowedCopies { get; set; }
    }
}