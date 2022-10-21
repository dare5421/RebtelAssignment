using Borrower.API.gRPC.Protos;
using Borrower.API.Models;
using Grpc.Core;
namespace Borrower.API.gRPC
{
    public class BorrowerGrpcService : BorrowerService.BorrowerServiceBase
    {
        private readonly IBorrowerRepository _borrowerRepository;

        public BorrowerGrpcService(IBorrowerRepository borrowerRepository)
        {
            _borrowerRepository = borrowerRepository;
        }

        public override async Task<GetBorrowersByIdsResponse> GetBorrowersByIds(GetBorrowersByIdsRequest request, ServerCallContext context)
        {
            var borrowersData = await _borrowerRepository.GetBorrowersByIds(request.BorrowerIds.ToArray());
            var response = new GetBorrowersByIdsResponse();
            foreach (var borrower in borrowersData)
            {
                response.Borrowers.Add(new GetBorrowersByIdsResponseItem
                {
                    Id = borrower.Id,
                    Address = borrower.Address,
                    BirthDate = borrower.BirthDate.ToString(),
                    Education = borrower.Education,
                    Name = borrower.Name,
                    RegistrationDate = borrower.RegistrationDate.ToString(),
                    Tel = borrower.Tel
                });
            }
            return response;

        }

        
    }
}
