using System.ComponentModel.DataAnnotations.Schema;

namespace Library.API.Models
{
    public class BookBorrow
    {
        public int Id { get; set; }
        [ForeignKey(nameof(BookId))]
        public virtual Book Book { get; set; }
        public int BookId { get; set; }
        public int BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime RetriveDate { get; set; }
    }
}