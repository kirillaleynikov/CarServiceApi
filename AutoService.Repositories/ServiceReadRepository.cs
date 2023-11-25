using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class ServiceReadRepository : IServiceReadRepository
    {
        private readonly ICarServiceContext context;

        public ServiceReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Service>> IServiceReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Services.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Name)
                .ToList());

        Task<Service?> IServiceReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Services.FirstOrDefault(x => x.Id == id));
    }
}
