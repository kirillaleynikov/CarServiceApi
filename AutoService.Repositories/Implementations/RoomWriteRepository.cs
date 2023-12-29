using CarService.Common.Entity.InterfaceDB;
using CarService.Context.Contracts.Models;
using CarService.Repositories.Contracts;
using CarService.Repositories.Anchors;

namespace CarService.Repositories.Implementations
{
    /// <inheritdoc cref="IRoomWriteRepository"/>
    public class RoomWriteRepository : BaseWriteRepository<Room>,
        IRoomWriteRepository,
        IRepositoryAnchor
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="RoomWriteRepository"/>
        /// </summary>
        public RoomWriteRepository(IDbWriterContext writerContext)
            : base(writerContext)
        {
        }
    }
}
