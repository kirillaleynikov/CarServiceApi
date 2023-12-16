using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.Models.Enums;

namespace CarService.Services.Implementations
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceReadRepository serviceReadRepository;

        public ServiceService(IServiceReadRepository serviceReadRepository)
        {
            this.serviceReadRepository = serviceReadRepository;
        }

        async Task<IEnumerable<ServiceModel>> IServiceService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await serviceReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new ServiceModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
            });
        }

        async Task<ServiceModel?> IServiceService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new ServiceModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
            };
        }
    }
}
