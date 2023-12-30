using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using CarService.Repositories.Anchors;


namespace CarService.Repositories
{
    public class ServiceReadRepository : IServiceReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ServiceReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Service>> IServiceReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Service>()
                .NotDeletedAt()
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Price)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Service?> IServiceReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Service>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Service>> IServiceReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Service>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellation);

        Task<bool> IServiceReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Service>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
    }
}
