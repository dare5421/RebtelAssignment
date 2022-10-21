namespace Borrower.API.Models
{
    public class Borrower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}
