using AutoMapper;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Common.Entity.InterfaceDB;
using CarService.Services.Contracts.Exceptions;
using CarService.Services.Contracts.Interface;

namespace CarService.Services.Implementations
{
    public class PartService : IPartService, IServiceAnchor
    {
        private readonly IPartReadRepository partReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPartWriteRepository partWriteRepository;

        public PartService(IPartReadRepository partReadRepository,
            IPartWriteRepository partWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this.partReadRepository = partReadRepository;
            this.partWriteRepository = partWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<PartModel>> IPartService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await partReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<PartModel>>(result);
        }

        async Task<PartModel?> IPartService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await partReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }
            return mapper.Map<PartModel>(item);
        }

        async Task<PartModel> IPartService.AddAsync(string name, DateTime dateOfBirth, string phoneNumber, CancellationToken cancellationToken)
        {
            var item = new Part
            {
                Id = Guid.NewGuid(),
                Name = name,
                DateOfBirth = dateOfBirth,
                PhoneNumber = phoneNumber,
            };

            partWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PartModel>(item);
        }

        async Task<PartModel> IPartService.EditAsync(EmployeeModel source, CancellationToken cancellationToken)
        {
            var targetPart = await partReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPart == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(source.Id);
            }

            targetPart.Name = source.Name;
            targetPart.DateOfBirth = source.DateOfBirth;
            targetPart.PhoneNumber = source.PhoneNumber;
            employeeWriteRepository.Update(targetPart);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PartModel>(targetPart);
        }

        async Task IPartService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetPart = await partReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetPart == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }

            if (targetPart.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Запчасть с идентификатором {id} уже удален");
            }

            partWriteRepository.Delete(targetPart);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
