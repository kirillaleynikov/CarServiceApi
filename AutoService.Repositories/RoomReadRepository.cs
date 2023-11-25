using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class RoomReadRepository : IRoomReadRepository
    {
        private readonly ICarServiceContext context;

        public RoomReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Room>> IRoomReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Rooms.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Number)
                .ToList());

        Task<Room?> IRoomReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Rooms.FirstOrDefault(x => x.Id == id));
    }
}
