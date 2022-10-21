namespace Borrower.API.Models
{
    public interface IBorrowerRepository
    {
        Task<List<Borrower>> GetAllBorrowersAsync();
        Task<List<Borrower>> GetBorrowersByIds(int[] ids);
    }
}
