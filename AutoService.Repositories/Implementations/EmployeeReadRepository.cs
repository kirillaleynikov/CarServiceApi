using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Anchors;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CarService.Repositories
{
    public class EmployeeReadRepository : IEmployeeReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public EmployeeReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе EmployeeReadRepository");
        }

        Task<IReadOnlyCollection<Employee>> IEmployeeReadRepository.GetAllAsync(CancellationToken cancellationToken)
            => reader.Read<Employee>()
                .NotDeletedAt()
                .OrderBy(x => x.Name)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Employee?> IEmployeeReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
                    => reader.Read<Employee>()
                        .ById(id)
                        .FirstOrDefaultAsync(cancellationToken);

        Task<Dictionary<Guid, Employee>> IEmployeeReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Employee>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(x => x.Id, cancellation);

        Task<bool> IEmployeeReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Employee>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
    }
}
