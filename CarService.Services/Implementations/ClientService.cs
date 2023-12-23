using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Common.Entity.InterfaceDB;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;
using System.Data;

namespace CarService.Services.Implementations
{
    public class ClientService : IClientService, IServiceAnchor
    {
        private readonly IClientReadRepository clientReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IClientWriteRepository clientWriteRepository;
        public ClientService(IClientReadRepository clientReadRepository,
            IClientWriteRepository clientWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.clientReadRepository = clientReadRepository;
            this.clientWriteRepository = clientWriteRepository;
            this.unitOfWork = unitOfWork;
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
                throw new CarServiceEntityNotFoundException<Client>(id);
            }
            return mapper.Map<ClientModel>(item); 
        }

        async Task<ClientModel> IClientService.AddAsync(string name, DateTime dateOfBirth, string phoneNumber, string email, CancellationToken cancellationToken)
        {
            var item = new Client
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
                Email = email
            };

            clientWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ClientModel>(item);
        }

        async Task<ClientModel> IClientService.EditAsync(ClientModel source, CancellationToken cancellationToken)
        {
            var targetClient = await clientReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(source.Id);
            }

            targetClient.Name = source.Name;
            targetClient.DateOfBirth = source.DateOfBirth;
            targetClient.PhoneNumber = source.PhoneNumber;
            targetClient.Email = source.Email;
            clientWriteRepository.Update(targetClient);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ClientModel>(targetClient);
        }

        async Task IClientService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetClient = await clientReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }

            if (targetClient.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Клиент с идентификатором {id} уже удален");
            }

            clientWriteRepository.Delete(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
