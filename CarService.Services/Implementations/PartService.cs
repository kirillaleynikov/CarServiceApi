using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;

namespace CarService.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly IPartReadRepository partReadRepository;

        public PartService(IPartReadRepository partReadRepository)
        {
            this.partReadRepository = partReadRepository;
        }

        async Task<IEnumerable<PartModel>> IPartService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await partReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new PartModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Auto = x.Auto,
                Country = x.Country,
            });
        }

        async Task<PartModel?> IPartService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await partReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new PartModel
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                Auto = item.Auto,
                Country = item.Country,
            };
        }
    }
}
