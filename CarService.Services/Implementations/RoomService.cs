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
    public class RoomService : IRoomService, IServiceAnchor
    {
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoomWriteRepository roomWriteRepository;
        private readonly IServiceValidatorService validatorService;
        public RoomService(IRoomReadRepository roomReadRepository,
            IRoomWriteRepository roomWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceValidatorService validatorService)
        {
            this.roomReadRepository = roomReadRepository;
            this.roomWriteRepository = roomWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.validatorService = validatorService;
        }

        async Task<IEnumerable<RoomModel>> IRoomService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await roomReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => mapper.Map<RoomModel>(x));
        }

        async Task<RoomModel?> IRoomService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                throw new CarServiceEntityNotFoundException<Room>(id);
            }
            return mapper.Map<RoomModel>(item);
        }

        async Task<RoomModel> IRoomService.AddAsync(RoomModel model, CancellationToken cancellationToken)
        {
            model.Id = Guid.NewGuid();
            await validatorService.ValidateAsync(model, cancellationToken);

            var item = mapper.Map<Room>(model);

            roomWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomModel>(item);
        }

        async Task<RoomModel> IRoomService.EditAsync(RoomModel source, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(source, cancellationToken);

            var targetClient = await roomReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Room>(source.Id);
            }

            targetClient = mapper.Map<Room>(source);

            roomWriteRepository.Update(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<RoomModel>(targetClient);
        }

        async Task IRoomService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetClient = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetClient == null)
            {
                throw new CarServiceEntityNotFoundException<Room>(id);
            }

            if (targetClient.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Запчасть с идентификатором {id} уже удален");
            }

            roomWriteRepository.Delete(targetClient);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
