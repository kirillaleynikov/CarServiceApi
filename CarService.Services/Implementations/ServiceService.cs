using AutoMapper;
using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.ModelsRequest;

namespace CarService.Services.Implementations
{
    public class ServiceService : IServiceService, IServiceAnchor
    {
        private readonly IServiceReadRepository serviceReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceWriteRepository serviceWriteRepository;

        public ServiceService(IServiceReadRepository serviceReadRepository,
            IServiceWriteRepository serviceWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.serviceReadRepository = serviceReadRepository;
            this.serviceWriteRepository = serviceWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<ServiceModel>> IServiceService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await serviceReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<ServiceModel>>(result);
        }

        async Task<ServiceModel?> IServiceService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Service>(id);
            }
            return mapper.Map<ServiceModel>(item);
        }

        async Task<ServiceModel> IServiceService.AddAsync(ServiceRequestModel serviceRequestModel, CancellationToken cancellationToken)
        {
            var item = new Service
            {
                Id = Guid.NewGuid(),
                Name = serviceRequestModel.Name,
                Price = serviceRequestModel.Price,
            };

            serviceWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ServiceModel>(item);
        }

        async Task<ServiceModel> IServiceService.EditAsync(ServiceRequestModel source, CancellationToken cancellationToken)
        {
            var targetService = await serviceReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetService == null)
            {
                throw new CarServiceEntityNotFoundException<Service>(source.Id);
            }

            targetService.Name = source.Name;
            targetService.Price = source.Price;

            serviceWriteRepository.Update(targetService);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<ServiceModel>(targetService);
        }

        async Task IServiceService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetService = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetService == null)
            {
                throw new CarServiceEntityNotFoundException<Service>(id);
            }

            if (targetService.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Клиент с идентификатором {id} уже удален");
            }

            serviceWriteRepository.Delete(targetService);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
