using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;

namespace CarService.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly IClientReadRepository clientReadRepository;

        public ClientService(IClientReadRepository clientReadRepository)
        {
            this.clientReadRepository = clientReadRepository;
        }

        async Task<IEnumerable<ClientModel>> IClientService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await clientReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new ClientModel
            {
                Id = x.Id,
                Name = x.Name,
                DateOfBirth = x.DateOfBirth,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
            });
        }

        async Task<ClientModel?> IClientService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await clientReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new ClientModel
            {
                Id = item.Id,
                Name = item.Name,
                DateOfBirth = item.DateOfBirth,
                PhoneNumber = item.PhoneNumber,
                Email = item.Email,
            };
        }
    }
}
