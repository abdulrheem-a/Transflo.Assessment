namespace Transflo.Assessment.Core.Features.Drivers.GetAlphabetizedDriverById
{
    public interface IGetAlphabetizedDriverByIdQueryRepository
    {
        Task<GetAlphabetizedDriverByIdResponse?> GetAlphabetizedDriverByIdAsync(int Id);
    }
}
