using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace CarService.Repositories
{
    public class PartReadRepository : IPartReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public PartReadRepository(IDbRead reader)
        {
            this.reader = reader;
        }

        Task<IReadOnlyCollection<Part>> IPartReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Part>()
                .NotDeletedAt()
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Part?> IPartReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Part>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);

        Task<bool> IPartReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
         => reader.Read<Part>()
             .NotDeletedAt()
             .ById(id)
             .AnyAsync(cancellationToken);

        Task<Dictionary<Guid, Part>> IPartReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Part>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellation);
    }
}
