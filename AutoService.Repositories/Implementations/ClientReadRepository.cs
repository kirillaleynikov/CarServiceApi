using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class ClientReadRepository : IClientReadRepository
    {
        private readonly ICarServiceContext context;

        public ClientReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Client>> IClientReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Clients.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Name)
                .ToList());

        Task<Client?> IClientReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Clients.FirstOrDefault(x => x.Id == id));
    }
}
