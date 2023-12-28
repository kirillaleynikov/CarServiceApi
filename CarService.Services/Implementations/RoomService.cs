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
    public class RoomService : IRoomService, IServiceAnchor
    {
        private readonly IRoomReadRepository roomReadRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRoomWriteRepository roomWriteRepository;
        public RoomService(IRoomReadRepository roomReadRepository,
            IRoomWriteRepository roomWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)        {
            this.roomReadRepository = roomReadRepository;
            this.roomWriteRepository = roomWriteRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        async Task<IEnumerable<RoomModel>> IRoomService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await roomReadRepository.GetAllAsync(cancellationToken);
            return mapper.Map<IEnumerable<RoomModel>>(result);
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

        async Task<RoomModel> IRoomService.AddAsync(RoomRequestModel roomRequestModel, CancellationToken cancellationToken)
        {
            var item = new Room
            {
                Id = Guid.NewGuid(),
                Number = roomRequestModel.Number,
                Square = roomRequestModel.Square,
                EmployeeId = roomRequestModel.EmployeeId,
                RoomType = (Context.Contracts.Enums.RoomTypes)roomRequestModel.RoomType,
            };

            roomWriteRepository.Add(item);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<RoomModel>(item);
        }

        async Task<RoomModel> IRoomService.EditAsync(RoomRequestModel source, CancellationToken cancellationToken)
        {
            var targetRoom = await roomReadRepository.GetByIdAsync(source.Id, cancellationToken);
            if (targetRoom == null)
            {
                throw new CarServiceEntityNotFoundException<Room>(source.Id);
            }

            targetRoom.Number = source.Number;
            targetRoom.Square = source.Square;
            targetRoom.EmployeeId = source.EmployeeId;
            targetRoom.RoomType = (Context.Contracts.Enums.RoomTypes)source.RoomType;
            roomWriteRepository.Update(targetRoom);

            await unitOfWork.SaveChangesAsync(cancellationToken);
            return mapper.Map<RoomModel>(targetRoom);
        }

        async Task IRoomService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var targetRoom = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (targetRoom == null)
            {
                throw new CarServiceEntityNotFoundException<Client>(id);
            }

            if (targetRoom.DeletedAt.HasValue)
            {
                throw new CarServiceInvalidOperationException($"Клиент с идентификатором {id} уже удален");
            }

            roomWriteRepository.Delete(targetRoom);
            await unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
