using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories
{
    public class PartReadRepository : IPartReadRepository
    {
        private readonly ICarServiceContext context;

        public PartReadRepository(ICarServiceContext context)
        {
            this.context = context;
        }

        Task<List<Part>> IPartReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => Task.FromResult(context.Parts.Where(x => x.DeletedAt == null)
                .OrderBy(x => x.Name)
                .ToList());

        Task<Part?> IPartReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => Task.FromResult(context.Parts.FirstOrDefault(x => x.Id == id));
    }
}
