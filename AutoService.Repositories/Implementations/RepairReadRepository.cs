using CarService.Common.Entity.InterfaceDB;
using CarService.Common.Entity.Repositories;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace CarService.Repositories.Implementations
{
    public class RepairReadRepository : IRepairReadRepository, IRepositoryAnchor
    {
        private readonly IDbRead reader;

        public RepairReadRepository(IDbRead reader)
        {
            this.reader = reader;
            Log.Information("Инициализирован абстракция IDbReader в классе RepairReadRepository");
        }

        Task<IReadOnlyCollection<Repair>> IRepairReadRepository.GetAllByDateAsync(DateTimeOffset startDate,
            DateTimeOffset endDate,
            CancellationToken cancellationToken)
            => reader.Read<Repair>()
                .NotDeletedAt()
                .Where(x => x.StartRepair >= startDate &&
                            x.EndRepair <= endDate)
                .OrderBy(x => x.StartRepair)
                .ToReadOnlyCollectionAsync(cancellationToken);

        Task<Repair?> IRepairReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
            => reader.Read<Repair>()
            .ById(id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}
