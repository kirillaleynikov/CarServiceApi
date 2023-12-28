using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

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
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Service?> IServiceReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Service>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<bool> IServiceReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
         => reader.Read<Service>()
             .NotDeletedAt()
             .ById(id)
             .AnyAsync(cancellationToken);

        Task<Dictionary<Guid, Service>> IServiceReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Service>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellation);
    }
}
