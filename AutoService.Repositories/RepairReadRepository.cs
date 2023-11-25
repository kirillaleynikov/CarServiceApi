using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class RepairReadRepository : IRepairReadRepository
    {
        private readonly ICarServiceContext context;

        public RepairReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Repair>> IRepairReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Repairs.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Service)
                .ToList());

        Task<Repair?> IRepairReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Repairs.FirstOrDefault(x => x.Id == id));
    }
}
