using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Common.Entity.InterfaceDB;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;
using System.Data;
using CarService.Services.Contracts.ModelsRequest;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarService.Services.Implementations
{
    public class ServiceService : IServiceService, IServiceAnchor
    {
        private readonly IServiceReadRepository serviceReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IServiceWriteRepository serviceWriteRepository;
        private readonly IServiceValidatorService validatorService;
        public ServiceService(IServiceReadRepository serviceReadRepository,
            IServiceWriteRepository serviceWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceValidatorService validatorService)
        {
            this.serviceReadRepository = serviceReadRepository;
            this.serviceWriteRepository = serviceWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        async Task<IEnumerable<ServiceModel>> IServiceService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await serviceReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<ServiceModel>(x));
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

        async Task<ServiceModel> IServiceService.AddAsync(ServiceModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();
            await validatorService.ValidateAsync(model, cancellationToken);

            var item = mapper.Map<Service>(model);

            serviceWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<ServiceModel>(item);
        }

        async Task<ServiceModel> IServiceService.EditAsync(ServiceModel source, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(source, cancellationToken);

            var targetService = await serviceReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetService == null)
            {
                throw new CarServiceEntityNotFoundException<Service>(source.Id);
            }

            targetService = mapper.Map<Service>(source);

            serviceWriteRepository.Update(targetService);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<ServiceModel>(targetService);
        }

        async Task IServiceService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetService = await serviceReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetService == null)
            {
                throw new CarServiceEntityNotFoundException<Room>(id);
            }

            if (targetService.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Запчасть с идентификатором {id} уже удален");
            }

            serviceWriteRepository.Delete(targetService);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
