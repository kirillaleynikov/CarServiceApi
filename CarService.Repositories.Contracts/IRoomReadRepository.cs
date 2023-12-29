using CarService.Context.Contracts.Models;

namespace CarService.Repositories.Contracts
{
    /// <summary>
    /// Репозиторий чтения <see cref="Room"/>
    /// </summary>
    public interface IRoomReadRepository
    {
        /// <summary>
        /// Получить список всех <see cref="Room"/>
        /// </summary>
        Task<IReadOnlyCollection<Room>> GetAllAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Получить <see cref="Room"/> по идентификатору
        /// </summary>
        Task<Room?> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список <see cref="Room"/> по идентификаторам
        /// </summary>
        Task<Dictionary<Guid, Room>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellation);

        /// <summary>
        /// Проверить есть ли <see cref="Room"/> в коллеции
        /// </summary>
        Task<bool> IsNotNullAsync(Guid id, CancellationToken cancellationToken);
    }
}
