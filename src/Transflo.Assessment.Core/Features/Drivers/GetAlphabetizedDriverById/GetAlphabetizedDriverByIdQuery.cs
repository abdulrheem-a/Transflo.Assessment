using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Transflo.Assessment.Shared.Models;

namespace Transflo.Assessment.Core.Features.Drivers.GetAlphabetizedDriverById
{
    public class GetAlphabetizedDriverByIdQuery : IRequest<ServiceResponse<GetAlphabetizedDriverByIdResponse>>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
    internal class GetAlphabetizedDriverByIdQueryHandler : IRequestHandler<GetAlphabetizedDriverByIdQuery, ServiceResponse<GetAlphabetizedDriverByIdResponse>>
    {
        private readonly IGetAlphabetizedDriverByIdQueryRepository _repository;

        public GetAlphabetizedDriverByIdQueryHandler(IGetAlphabetizedDriverByIdQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse<GetAlphabetizedDriverByIdResponse>> Handle(GetAlphabetizedDriverByIdQuery request, CancellationToken cancellationToken)
        {
            var _driver = await _repository.GetAlphabetizedDriverByIdAsync(request.Id);
            if (_driver == null)
                return new ValidationErrorServiceResponse<GetAlphabetizedDriverByIdResponse>("Driver not found");

            return new SuccessServiceResponse<GetAlphabetizedDriverByIdResponse>(_driver);

        }
    }
}
