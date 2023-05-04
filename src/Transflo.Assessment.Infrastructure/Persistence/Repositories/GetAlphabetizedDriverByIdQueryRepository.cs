using Microsoft.EntityFrameworkCore;
using Transflo.Assessment.Core.Features.Drivers.GetAlphabetizedDriverById;
using Transflo.Assessment.Shared.Extensions;
namespace Transflo.Assessment.Infrastructure.Persistence.Repositories
{
    internal class GetAlphabetizedDriverByIdQueryRepository : IGetAlphabetizedDriverByIdQueryRepository
    {
        private readonly TransfloAssessmentContext _context;

        public GetAlphabetizedDriverByIdQueryRepository(TransfloAssessmentContext context)
        {
            _context = context;
        }
        public async Task<GetAlphabetizedDriverByIdResponse?> GetAlphabetizedDriverByIdAsync(int Id)
        {
            return await _context.Drivers.AsNoTracking().Where(x => x.Id == Id).Select(x=> new GetAlphabetizedDriverByIdResponse
            {
                Id= Id, 
                FullName= x.FirstName.GetAlphabetizedString() +" " +x.LastName.GetAlphabetizedString()
            }).SingleOrDefaultAsync();
        }
    }
}
