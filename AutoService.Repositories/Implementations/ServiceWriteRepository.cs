using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Anchors;
using CarService.Repositories.Contracts;

namespace CarService.Repositories.Implementations
{
    /// <inheritdoc cref="IServiceWriteRepository"/>
    public class ServiceWriteRepository : BaseWriteRepository<Service>,
        IServiceWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ServiceWriteRepository"/>
        /// </summary>
        public ServiceWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
