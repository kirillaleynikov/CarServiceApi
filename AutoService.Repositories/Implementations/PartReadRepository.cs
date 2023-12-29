using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Anchors;
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

        Task<Dictionary<Guid, Part>> IPartReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Part>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(x => x.Id, cancellation);

        Task<bool> IPartReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Part>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
    }
}
