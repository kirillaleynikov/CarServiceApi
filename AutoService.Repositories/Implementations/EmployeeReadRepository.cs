using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts.Models;
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

        Task<bool> IEmployeeReadRepository.AnyByIdAsync(Guid id, CancellationToken cancellationToken)
         => reader.Read<Employee>()
             .NotDeletedAt()
             .ById(id)
             .AnyAsync(cancellationToken);

        Task<Dictionary<Guid, Employee>> IEmployeeReadRepository.GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation)
            => reader.Read<Employee>()
                .NotDeletedAt()
                .ByIds(ids)
                .OrderBy(x => x.Name)
                .ToDictionaryAsync(key => key.Id, cancellation);
    }
}
