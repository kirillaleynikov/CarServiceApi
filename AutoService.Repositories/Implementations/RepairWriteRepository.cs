using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;

namespace CarService.Repositories.Implementations
{
    /// <inheritdoc cref="IRepairWriteRepository"/>
    public class RepairWriteRepository : BaseWriteRepository<Repair>,
        IRepairWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="RepairWriteRepository"/>
        /// </summary>
        public RepairWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
