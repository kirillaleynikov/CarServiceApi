using CarService.Repositories.Contracts;
using CarService.Services.Contracts;
using CarService.Services.Contracts.Models;
using CarService.Services.Contracts.Models.Enums;

namespace CarService.Services.Implementations
{
    public class RoomService : IRoomService
    {
        private readonly IRoomReadRepository roomReadRepository;

        public RoomService(IRoomReadRepository roomReadRepository)
        {
            this.roomReadRepository = roomReadRepository;
        }

        async Task<IEnumerable<RoomModel>> IRoomService.GetAllAsync(CancellationToken cancellationToken)
        {
            var result = await roomReadRepository.GetAllAsync(cancellationToken);
            return result.Select(x => new RoomModel
            {
                Id = x.Id,
                Number = x.Number,
                Square = x.Square,
                EmployeeId = x.EmployeeId,
                RoomType = x.RoomType,
            });
        }

        async Task<RoomModel?> IRoomService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var item = await roomReadRepository.GetByIdAsync(id, cancellationToken);
            if (item == null)
            {
                return null;
            }

            return new RoomModel
            {
                Id = item.Id,
                Number = item.Number,
                Square = item.Square,
                EmployeeId = item.EmployeeId,
                RoomType = item.RoomType,
            };
        }
    }
}
