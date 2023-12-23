using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;

namespace CarService.Repositories.Implementations
{
    public class ClientReadRepository : IClientReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public ClientReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Client>> IClientReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Client>()
            .NotDeletedAt()
            .OrderBy(x => x.Name)
            .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Client?> IClientReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Client>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<bool> IClientReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
         => reader.Read<Client>()
             .NotDeletedAt()
             .ById(id)
             .AnyAsync(cancellationToken);

        Task<Dictionary<Guid, Client>> IClientReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Client>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellation);
    }
}
