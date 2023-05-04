using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using Transflo.Assessment.Core.Domain;
using Transflo.Assessment.Core.Features.Drivers.Update;
using Transflo.Assessment.Core.Interfaces.Repositories;
using Transflo.Assessment.Shared.Models;

namespace Transflo.Assessment.Core.Features.Drivers.Delete
{
    public class DeleteDriverCommand: IRequest<ServiceResponse<DeleteDriverCommandResponse>>
    {
        [FromRoute(Name = "id")]
        public int Id { get; set; }
    }
    internal class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, ServiceResponse<DeleteDriverCommandResponse>>
    {
        private readonly IGenericRepository<Driver> _repository;

        public DeleteDriverCommandHandler(IGenericRepository<Driver> repository)
        {
            _repository = repository;
        }
        public async Task<ServiceResponse<DeleteDriverCommandResponse>> Handle(DeleteDriverCommand request, CancellationToken cancellationToken)
        {
            var _driver = await _repository.GetAsync(drv => drv.Id == request.Id);
            if (_driver == null)
                return new ValidationErrorServiceResponse<DeleteDriverCommandResponse>("Driver not found");

             _repository.Delete(_driver);
            await _repository.SaveChangesAsync();

            return new SuccessServiceResponse<DeleteDriverCommandResponse>(new DeleteDriverCommandResponse()
            {
                Id = _driver.Id
            });
        }
    }
}
