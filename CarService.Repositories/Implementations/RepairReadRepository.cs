//using CarService.Common.Entity.InterfaceDB;
//using CarService.Common.Entity.Repositories;
//using CarService.Context.Contracts.Models;
//using CarService.Repositories.Anchors;
//using CarService.Repositories.Contracts;
//using Microsoft.EntityFrameworkCore;
//using Serilog;

//namespace CarService.Repositories.Implementations
//{
//    public class RepairReadRepository : IRepairReadRepository, IRepositoryAnchor
//    {
//        private readonly IDbRead reader;

//        public RepairReadRepository(IDbRead reader)
//        {
//            this.reader = reader;
//            Log.Information("Инициализирован абстракция IDbReader в классе RepairReadRepository");
//        }

//        Task<IReadOnlyCollection<Repair>> IRepairReadRepository.GetAllAsync(CancellationToken cancellationToken)
//             => reader.Read<Repair>()
//                 .NotDeletedAt()
//         .OrderBy(x => x.StartRepair)
//                 .ToReadOnlyCollectionAsync(cancellationToken);

//        Task<Repair?> IRepairReadRepository.GetByIdAsync(Guid id, CancellationToken cancellationToken)
//            => reader.Read<Repair>()
//            .ById(id)
//            .FirstOrDefaultAsync(cancellationToken);

//        Task<bool> IRepairReadRepository.IsNotNullAsync(Guid id, CancellationToken cancellationToken)
//            => reader.Read<Repair>().AnyAsync(x => x.Id == id && !x.DeletedAt.HasValue, cancellationToken);
//    }
//}
