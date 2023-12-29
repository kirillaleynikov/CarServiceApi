using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Repositories.Anchors;

namespace CarService.Repositories.Implementations
{
    /// <inheritdoc cref="IPartWriteRepository"/>
    public class PartWriteRepository : BaseWriteRepository<Part>,
        IPartWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="PartWriteRepository"/>
        /// </summary>
        public PartWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
