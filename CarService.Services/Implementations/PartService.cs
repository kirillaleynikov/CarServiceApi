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

        async Task<PartModel> IPartService.AddAsync(string name, int price, string auto, string country, CancellationToken cancellationToken)
        {
            var item = new Part
            {
                Id = Guid.NewGuid(),
                Name = name,
                Price = price,
                Auto = auto,
                Country = country
            };

            partWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PartModel>(item);
        }

        async Task<PartModel> IPartService.EditAsync(PartModel source, CancellationToken cancellationToken)
        {
            var targetPart = await partReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetPart == null)
            {
                throw new CarServiceEntityNotFoundException<Part>(source.Id);
            }

            targetPart.Name = source.Name;
            targetPart.Price = source.Price;
            targetPart.Auto = source.Auto;
            targetPart.Country = source.Country;
            partWriteRepository.Update(targetPart);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<PartModel>(targetPart);
        }

        async Task IPartService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetPart = await partReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetPart == null)
            {
                throw new CarServiceEntityNotFoundException<Part>(id);
            }

            if (targetPart.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Запчасть с идентификатором {id} уже удалена");
            }

            partWriteRepository.Delete(targetPart);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
