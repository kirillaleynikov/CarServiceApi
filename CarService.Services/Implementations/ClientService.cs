using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;
using System.Data;

namespace CarService.Services.Implementations
{
    public class ClientService : IClientService, IServiceAnchor
    {
        private readonly IClientReadRepository clientReadRepository;
        private readonly IMapper mapper;
        public ClientService(IClientReadRepository clientReadRepository
            IMapper mapper)
        {
            this.clientReadRepository = clientReadRepository;
            this.mapper = mapper;
        }

        async Task<IEnumerable<ClientModel>> IClientService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await clientReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ClientModel>>(result);
        }

        async Task<ClientModel?> IClientService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await clientReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new AutoServiceEntityNotFoundException<Client>(id);
            }
            return mapper.Map<ClientModel>(item); 
        }
    }
}
